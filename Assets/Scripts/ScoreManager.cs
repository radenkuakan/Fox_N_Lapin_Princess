using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Wajib ada untuk akses TextMeshPro

public class ScoreManager : MonoBehaviour
{
    // Bikin "instance" statis biar script ini bisa dipanggil dari mana aja dengan mudah
    public static ScoreManager instance;

    public TextMeshProUGUI textSkor; // Kotak untuk masukin UI Text
    int nilaiSkor = 0; // Variabel penyimpan angka skor

    void Awake()
    {
        // Set diri sendiri sebagai pengelola utama saat game mulai
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // Pastikan skor awal 0 dan tertulis di layar
        textSkor.text = "SCORE: " + nilaiSkor.ToString();
    }

    // Fungsi ini akan dipanggil oleh Buah nanti
    public void TambahSkor(int jumlah)
    {
        nilaiSkor += jumlah; // Tambahkan skor
        textSkor.text = "SCORE: " + nilaiSkor.ToString(); // Update tulisan di layar
    }
}
