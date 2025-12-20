using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    // Kita TIDAK BUTUH referensi GameManager disini lagi
    // Karena kita akan numpang lewat Player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah yang ditabrak itu Player?
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Ambil Skrip PlayerMovement dari benda yang ditabrak
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

            // 2. Suruh Player yang mengurus kematiannya sendiri
            if (player != null)
            {
                // Panggil fungsi TriggerHurt() yang ada di Player.
                // Fungsi ini AMAN karena di dalamnya sudah ada gembok 'if (isDead) return;'
                // Jadi suara game over DIJAMIN cuma bunyi 1 kali.
                player.TriggerHurt();
            }
        }
    }

    // Jaga-jaga kalau duri kamu pakai "Is Trigger" (bukan Collision fisik)
    // Tambahkan juga fungsi ini biar aman:
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.TriggerHurt();
            }
        }
    }
}