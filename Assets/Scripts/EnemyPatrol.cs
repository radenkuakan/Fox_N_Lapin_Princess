using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Titik Pembatas")]
    public Transform titikA; // Batas Kiri
    public Transform titikB; // Batas Kanan

    [Header("Pengaturan Gerak")]
    public float kecepatan = 2f;
    private Rigidbody2D rb;
    private Transform tujuanSaatIni; // Musuh lagi mau jalan ke mana?
    //private Animator anim; // Biar bisa set animasi jalan (kalau ada)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        // Target pertama kita set ke Titik B dulu
        tujuanSaatIni = titikB;
        //anim.SetBool("IsRunning", true); // Nyalakan animasi lari (sesuaikan nama parameter di Animator kamu)
    }

    void Update()
    {
        // --- PERBAIKAN DI SINI ---
        // Ganti "Vector2.Distance" dengan "Mathf.Abs"
        // Kita cuma cek selisih posisi X (Kiri-Kanan). Abaikan tinggi Y.
        // Jadi walaupun titiknya melayang dikit, musuh tetap sadar kalau dia udah sampai.
        if (Mathf.Abs(transform.position.x - tujuanSaatIni.position.x) < 0.5f)
        {
            // Kalau target sekarang adalah Titik B (Kanan)
            if (tujuanSaatIni == titikB)
            {
                tujuanSaatIni = titikA; // Ganti tujuan ke Kiri
                BalikBadan(true);       // Hadap Kiri
            }
            // Kalau target sekarang adalah Titik A (Kiri)
            else
            {
                tujuanSaatIni = titikB; // Ganti tujuan ke Kanan
                BalikBadan(false);      // Hadap Kanan
            }
        }

        // --- BAGIAN BAWAH INI TETAP SAMA ---
        Vector2 arah = (tujuanSaatIni.position - transform.position).normalized;
        rb.velocity = new Vector2(arah.x * kecepatan, rb.velocity.y);
    }

    // Fungsi simpel buat membalik sprite
    void BalikBadan(bool hadapKiri)
    {
        if (hadapKiri)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip X jadi -1
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1); // Normal
        }
    }

    // Biar musuh diem kalau mati/nabrak tembok aneh
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player yang urus logikanya (lewat script EnemyKiller)
        }
    }

    // --- TAMBAHAN FITUR VISUAL ---
    // Ini biar muncul garis merah di Scene View, jadi gampang atur posisinya
    private void OnDrawGizmos()
    {
        if (titikA != null && titikB != null)
        {
            // Gambar garis merah dari A ke B
            Gizmos.color = Color.red;
            Gizmos.DrawLine(titikA.position, titikB.position);

            // Gambar bola kecil di ujung-ujungnya
            Gizmos.DrawSphere(titikA.position, 0.2f);
            Gizmos.DrawSphere(titikB.position, 0.2f);
        }
    }
}