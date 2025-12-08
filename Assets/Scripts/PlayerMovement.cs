using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private float horizontalInput;
    public bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // --- TAMBAHKAN BARIS INI ---
            if (SFXManager.instance != null)
            {
                SFXManager.instance.MainkanJump();
            }
        }



        if (horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    // --- PERUBAHAN DI SINI ---

    // DULU: OnCollisionEnter2D (Cuma sekali cek)
    // SEKARANG: OnCollisionStay2D (Cek terus menerus setiap frame selama nempel)
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Cek terus menerus: Apakah ada sisi yang menghadap ke atas?
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    return; // Kalau ketemu lantai, langsung keluar (hemat kinerja)
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
