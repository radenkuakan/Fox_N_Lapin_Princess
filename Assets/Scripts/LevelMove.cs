using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    [Header("Pengaturan Mode")]
    // Kalau dicentang = Muncul Panel Menang dulu (Untuk Level 1, 2, dst)
    // Kalau tidak dicentang = Langsung Pindah (Untuk Intro)
    public bool pakaiPanelMenang = true;

    [Header("UI References")]
    public GameObject winPanel; // Masukkan Panel Win (Cuma butuh kalau pakaiPanelMenang dicentang)

    [Header("Tujuan Selanjutnya")]
    public string namaSceneSelanjutnya; // Ketik nama scene tujuan

    // Dipanggil saat Player menabrak tiang finis
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pakaiPanelMenang == true)
            {
                // MODE 1: Munculkan Panel dulu (Untuk Level)
                Menang();
            }
            else
            {
                // MODE 2: Langsung Pindah (Untuk Intro)
                SceneManager.LoadScene(namaSceneSelanjutnya);
            }
        }
    }

    void Menang()
    {
        // 1. Matikan Musik Background (Biar suara menangnya jelas)
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.MatikanMusik();
        }

        // 2. Mainkan Suara Level Complete (Hore!)
        if (SFXManager.instance != null)
        {
            SFXManager.instance.MainkanLevelComplete();
        }

        // 3. Munculkan panel & Hentikan waktu
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    // Fungsi ini dipasang di Tombol "Next Level" pada Panel
    public void PindahKeLevelBerikutnya()
    {
        Time.timeScale = 1f;

        // --- NYALAKAN MUSIK LAGI SEBELUM PINDAH ---
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.NyalakanMusik();
        }
        // ------------------------------------------

        SceneManager.LoadScene(namaSceneSelanjutnya);
    }
}
