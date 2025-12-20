using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Wajib buat pindah scene

public class PauseController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pausePanel; // Masukkan Panel Pause di sini

    // Variabel untuk mengecek status game
    public static bool isPaused = false;

    void Start()
    {
        // Pastikan saat mulai, panel mati dan waktu berjalan normal
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Fungsi dipanggil saat tombol HUD "Menu" ditekan
    public void TekanPause()
    {
        pausePanel.SetActive(true); // Munculkan panel
        Time.timeScale = 0f;        // Bekukan waktu (STOP TOTAL)
        isPaused = true;
    }

    // Fungsi dipanggil saat tombol "Resume" ditekan
    public void TekanResume()
    {
        pausePanel.SetActive(false); // Sembunyikan panel
        Time.timeScale = 1f;         // Jalankan waktu lagi (NORMAL)
        isPaused = false;
    }

    // Fungsi untuk tombol "Main Menu"
    public void KeMainMenu()
    {
        // 1. PENTING! Balikkan waktu ke normal dulu
        Time.timeScale = 1f;

        // 2. TAMBAHAN PENTING: RESET SKOR
        // Bilang ke ScoreManager: "Hapus skor lama, kita mau balik ke menu!"
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }

        // 3. Baru pindah scene
        SceneManager.LoadScene("Main_Menu");
    }
}