using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Pengaturan Panel Options")]
    public GameObject optionsPanel;

    // --- FUNGSI UTAMA TOMBOL START ---
    public void MulaiPermainanBaru(string namaScene)
    {
        // 1. RESET SKOR (Tugas Utama dia)
        PlayerPrefs.DeleteKey("SkorSementara");
        // Kalau ScoreManager ada di menu, reset juga
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }

        // 2. PANGGIL LEVEL LOADER (Buat Transisi)
        // Kita cari script LevelLoader yang ada di scene ini
        LevelLoader loader = FindObjectOfType<LevelLoader>();

        if (loader != null)
        {
            // Kalau ada LevelLoader, suruh dia yang pindahin scene (biar ada Fade)
            loader.LoadNextLevel(namaScene);
        }
        else
        {
            // Jaga-jaga kalau lupa naruh LevelLoader, pindah biasa
            SceneManager.LoadScene(namaScene);
        }
    }

    // --- FUNGSI LAINNYA (Biarkan Saja) ---
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