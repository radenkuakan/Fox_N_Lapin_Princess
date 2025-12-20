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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (isDead) return;

        // 1. INPUT
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 2. LOMPAT
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (anim != null) anim.SetTrigger("jump");
            if (SFXManager.instance != null) SFXManager.instance.MainkanJump();
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

    // --- FUNGSI SAKIT (PUSAT LOGIKA MATI) ---
    // Sekarang semua efek (Suara, Musik, Panel) dijalankan DISINI.
    public void TriggerHurt()
    {
        // 1. GEMBOK PENGAMAN (Penting!)
        // Kalau sudah mati, stop. Jangan jalankan suara lagi.
        if (isDead == true) return;

        // Kunci status mati
        isDead = true;

        // 2. Mainkan Animasi
        if (anim != null) anim.SetTrigger("hurt");

        // 3. Matikan Musik Background
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.MatikanMusik();
        }

        // 4. Mainkan Suara Game Over (HANYA SEKALI DISINI)
        if (SFXManager.instance != null)
        {
            SFXManager.instance.MainkanGameOver();
        }

        // 5. Panggil GameOverManager
        GameOverManager gm = FindObjectOfType<GameOverManager>();
        if (gm != null)
        {
            // Kita panggil fungsi PlayerMati() yang ada di script GameOverManager kamu
            gm.PlayerMati();
        }
    }

    // --- DETEKSI TABRAKAN ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kalau sudah mati, abaikan semua tabrakan
        if (isDead == true) return;

        // Cek apakah kena Musuh?
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Cukup panggil TriggerHurt.
            // Biarkan TriggerHurt yang mengurus suara & panelnya.
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