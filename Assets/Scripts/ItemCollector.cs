using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    // Berapa poin yang didapat dari buah ini?
    public int poin = 1;

    // Fungsi bawaan Unity saat ada yang masuk ke trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang nabrak itu Player?
        if (collision.CompareTag("Player"))
        {
            // 1. Panggil ScoreManager untuk nambah poin
            ScoreManager.instance.TambahSkor(poin);

            // 2. Mainkan Suara Collect (BARU)
            if (SFXManager.instance != null)
            {
                SFXManager.instance.MainkanCollect();
            }

            // 2. Hancurkan buah ini (biar hilang dari layar)
            Destroy(gameObject);
        }
    }
}
