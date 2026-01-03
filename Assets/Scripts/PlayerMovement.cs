using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Komponen Animasi")]
    public Animator anim;

    [Header("Pengaturan Gerak")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private float horizontalInput;
    public bool isGrounded;

    private bool isDead = false;

    // --- [BARU] VARIABEL KHUSUS ANDROID ---
    // Ini saklar untuk mengetahui apakah tombol layar sedang ditekan
    private bool tekanKiri = false;
    private bool tekanKanan = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (isDead) return;

        // --- 1. LOGIKA INPUT GABUNGAN (KEYBOARD + ANDROID) ---

        // A. Ambil dari Keyboard dulu (Default)
        float inputKeyboard = Input.GetAxisRaw("Horizontal");

        // B. Ambil dari Tombol Layar (Android)
        float inputAndroid = 0f;
        if (tekanKiri)
        {
            inputAndroid = -1f; // Gerak Kiri
        }
        else if (tekanKanan)
        {
            inputAndroid = 1f;  // Gerak Kanan
        }

        // C. Gabungkan!
        // Kalau keyboard ditekan, dia jalan. Kalau tombol layar ditekan, dia juga jalan.
        horizontalInput = inputKeyboard + inputAndroid;

        // Kunci nilainya biar gak lebih dari 1 atau kurang dari -1
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);

        // -----------------------------------------------------

        // 2. LOMPAT (KEYBOARD)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            LakukanLompat(); // Kita panggil fungsi lompat
        }

        // 3. FLIP BADAN
        if (horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);

        // 4. ANIMASI
        if (anim != null)
        {
            anim.SetBool("run", Mathf.Abs(horizontalInput) > 0);
            anim.SetBool("grounded", isGrounded);
        }
    }

    void FixedUpdate()
    {
        if (isDead)
        {
            rb.velocity = Vector2.zero; // Stop fisik
            return;
        }
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    // --- [BARU] FUNGSI UNTUK TOMBOL UI ANDROID ---

    // Dipanggil saat tombol KIRI ditekan (Pointer Down)
    public void TekanKiri()
    {
        tekanKiri = true;
    }
    // Dipanggil saat tombol KIRI dilepas (Pointer Up)
    public void LepasKiri()
    {
        tekanKiri = false;
    }

    // Dipanggil saat tombol KANAN ditekan
    public void TekanKanan()
    {
        tekanKanan = true;
    }
    // Dipanggil saat tombol KANAN dilepas
    public void LepasKanan()
    {
        tekanKanan = false;
    }

    // Dipanggil saat tombol JUMP ditekan (Tap)
    public void LakukanLompat()
    {
        // Cek syarat lompat disini biar tombol UI juga patuh aturan
        if (isGrounded && !isDead)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (anim != null) anim.SetTrigger("jump");
            if (SFXManager.instance != null) SFXManager.instance.MainkanJump();
        }
    }

    // ---------------------------------------------

    // --- FUNGSI SAKIT (PUSAT LOGIKA MATI) ---
    public void TriggerHurt()
    {
        if (isDead == true) return;

        isDead = true;

        if (anim != null) anim.SetTrigger("hurt");

        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.MatikanMusik();
        }

        if (SFXManager.instance != null)
        {
            SFXManager.instance.MainkanGameOver();
        }

        GameOverManager gm = FindObjectOfType<GameOverManager>();
        if (gm != null)
        {
            gm.PlayerMati();
        }
    }

    // --- DETEKSI TABRAKAN ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead == true) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TriggerHurt();
        }
    }

    // --- LOGIKA TANAH ---
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.9f)
                {
                    isGrounded = true;
                    return;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}