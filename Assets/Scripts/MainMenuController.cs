using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Pengaturan Panel Options")]
    public GameObject optionsPanel;

    [Header("Display Nama Player")]
    public TextMeshProUGUI teksNamaDisplay;

    // --- FUNGSI START (Dipanggil otomatis) ---
    void Start()
    {
        // 1. Setting FPS & VSync (Kode Asli Kamu)
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        // 2. Tampilkan Nama Player
        if (teksNamaDisplay != null)
        {
            if (PlayerPrefs.HasKey("NamaPlayer"))
            {
                string nama = PlayerPrefs.GetString("NamaPlayer");
                teksNamaDisplay.text = nama; // Sesuai request (tanpa "Hi")
            }
            else
            {
                teksNamaDisplay.text = "Player";
            }
        }
    }
    // ------------------------------------

    // --- FUNGSI UTAMA TOMBOL START ---
    public void MulaiPermainanBaru(string namaScene)
    {
        // 1. RESET SKOR
        PlayerPrefs.DeleteKey("SkorSementara");

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }

        // 2. PANGGIL LEVEL LOADER
        LevelLoader loader = FindObjectOfType<LevelLoader>();

        if (loader != null)
        {
            loader.LoadNextLevel(namaScene);
        }
        else
        {
            SceneManager.LoadScene(namaScene);
        }
    }

    // --- FUNGSI GANTI NAMA (FITUR BARU) ---
    public void GantiNamaPlayer()
    {
        // 1. HAPUS Data Nama Lama
        // Ini penting! Kalau tidak dihapus, scene ProfileSetup akan otomatis
        // melempar balik ke MainMenu karena mengira nama masih ada.
        PlayerPrefs.DeleteKey("NamaPlayer");
        PlayerPrefs.Save(); // Pastikan terhapus detik ini juga

        // 2. Pindah ke Scene Input Nama
        // Pastikan nama scenenya sama persis dengan yang kamu buat
        SceneManager.LoadScene("ProfileSetup");
    }

    // --- FUNGSI LAINNYA (SAMA SEPERTI SEBELUMNYA) ---
    public void PindahKeScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void BukaOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void TutupOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void KeluarGame()
    {
        Debug.Log("Keluar Game...");
        Application.Quit();
    }

    [Header("Panel UI")]
    public GameObject aboutPanel;

    public void BukaAbout()
    {
        aboutPanel.SetActive(true);
    }

    public void TutupAbout()
    {
        aboutPanel.SetActive(false);
    }
}