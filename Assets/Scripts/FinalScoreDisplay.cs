using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Wajib karena pakai TextMeshPro

public class FinalScoreDisplay : MonoBehaviour
{
    [Header("UI Reference")]
    // Tarik objek Text skor yang baru kamu buat ke sini
    public TextMeshProUGUI textSkorAkhir;

    // Fungsi OnEnable dipanggil OTOMATIS setiap kali Panel ini Muncul (SetActive true)
    void OnEnable()
    {
        if (ScoreManager.instance != null)
        {
            // 1. Ambil nilai skor terakhir yang sedang aktif
            int skorFinal = ScoreManager.instance.nilaiSkor;

            // 2. Tampilkan ke layar
            textSkorAkhir.text = "FINAL SCORE: " + skorFinal.ToString();

            // (Opsional) Kalau mau Simpan Skor ke Highscore Permanen, bisa disini.
            // Tapi untuk sekarang tampilkan saja dulu.
        }
    }
}