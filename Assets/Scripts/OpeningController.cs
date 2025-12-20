using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningController : MonoBehaviour
{
    [Header("Pengaturan Waktu")]
    public float durasiTampil = 3f; // Berapa lama opening tampil (detik)
    public string sceneSelanjutnya = "Main_Menu"; // Nama scene tujuan

    void Start()
    {
        // Panggil fungsi PindahScene setelah waktu yang ditentukan
        Invoke("PindahScene", durasiTampil);
    }

    void PindahScene()
    {
        // --- BAGIAN BARU: RESET SKOR (PENTING) ---
        // Kita sisipkan disini. Sebelum pindah, hapus dulu skornya.
        PlayerPrefs.DeleteKey("SkorSementara");

        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore();
        }
        // -----------------------------------------

        // 1. Cari objek yang punya script LevelLoader di scene ini
        LevelLoader loader = FindObjectOfType<LevelLoader>();

        // 2. Cek apakah LevelLoader ditemukan
        if (loader != null)
        {
            // Kalau ada, suruh dia yang pindah scene (pakai fade out)
            loader.LoadNextLevel(sceneSelanjutnya);
        }
        else
        {
            // Jaga-jaga kalau lupa naruh LevelLoader, pindah scene biasa
            SceneManager.LoadScene(sceneSelanjutnya);
        }
    }
}