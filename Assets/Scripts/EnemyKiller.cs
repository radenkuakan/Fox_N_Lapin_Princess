using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    // Variabel untuk menyimpan referensi ke Game Manager
    private GameOverManager gameManager;

    void Start()
    {
        // CARI OTOMATIS: Script ini akan mencari benda yang punya GameOverManager di scene
        // Jadi kamu TIDAK PERLU drag-drag manual lagi. Praktis!
        gameManager = FindObjectOfType<GameOverManager>();
    }

    // Gunakan OnCollision (Tabrakan Fisik) bukan OnTrigger
    // Karena musuh itu padat dan berjalan di tanah
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek apakah yang ditabrak itu Player?
        if (collision.gameObject.CompareTag("Player"))
        {
            // Panggil fungsi mati
            gameManager.PlayerMati();
        }
    }
}
