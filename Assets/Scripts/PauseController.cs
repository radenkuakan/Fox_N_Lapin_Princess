using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Wajib buat pindah scene

public class PauseController : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pausePanel; // Masukkan Panel Pause di sini

    // Variabel untuk mengecek status game (sedang pause atau tidak)
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
        Time.timeScale = 1f; // PENTING! Balikkan waktu ke normal sebelum pindah scene
        SceneManager.LoadScene("Main_Menu"); // Pastikan nama scene sesuai
    }
}
