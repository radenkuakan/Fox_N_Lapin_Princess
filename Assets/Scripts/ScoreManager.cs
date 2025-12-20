using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Wajib karena pakai TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    // Masukkan Text (TMP) skor ke sini di Inspector
    public TextMeshProUGUI textSkor;

    // Variabel skor (integer)
    public int nilaiSkor = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // --- BAGIAN LOAD (PENTING) ---
        // Saat scene dimulai, kita CEK apakah ada skor tersimpan?
        // Kalau ada, ambil nilainya. Kalau tidak ada, mulai dari 0.
        // "SkorSementara" adalah nama kunci brankasnya.
        nilaiSkor = PlayerPrefs.GetInt("SkorSementara", 0);

        // Update tampilan teks biar langsung sesuai angka yang di-load
        UpdateUI();
    }

    // Nama fungsi tetap "TambahSkor" biar aman
    public void TambahSkor(int jumlah)
    {
        nilaiSkor += jumlah;
        UpdateUI();
    }

    // Fungsi update teks biar rapi
    void UpdateUI()
    {
        if (textSkor != null)
        {
            textSkor.text = "SCORE: " + nilaiSkor.ToString();
        }
    }

    // --- FUNGSI SIMPAN (Dipanggil pas Tamat Level) ---
    // Pasang ini di skrip LevelMove nanti
    public void SimpanSkor()
    {
        PlayerPrefs.SetInt("SkorSementara", nilaiSkor);
        PlayerPrefs.Save(); // Kunci brankasnya biar aman
    }

    // --- FUNGSI RESET (Dipanggil pas Main Menu / Game Baru) ---
    // PENTING: Panggil ini di tombol "Play" di Main Menu
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("SkorSementara"); // Hapus simpanan
        nilaiSkor = 0;
        UpdateUI();
    }
}