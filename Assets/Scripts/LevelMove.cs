using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    [Header("Pengaturan Mode")]
    // Centang = Muncul Panel Menang dulu (Level 1)
    // Jangan Centang = Langsung Transisi (Intro)
    public bool pakaiPanelMenang = true;

    [Header("UI References")]
    public GameObject winPanel;

    [Header("Tujuan Selanjutnya")]
    public string namaSceneSelanjutnya;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // --- MATIKAN GERAKAN PLAYER ---
            PlayerMovement playerScript = other.GetComponent<PlayerMovement>();
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            if (playerScript != null)
            {
                if (playerScript.anim != null)
                {
                    playerScript.anim.SetBool("run", false);
                }
                playerScript.enabled = false;
            }

            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
                playerRb.bodyType = RigidbodyType2D.Kinematic;
            }
            // ---------------------------------------------

            if (pakaiPanelMenang == true)
            {
                // JALUR 1: Munculkan Panel Menang
                Menang();
            }
            else
            {
                // JALUR 2: Langsung Pindah (Intro)

                // --- SIMPAN SKOR DISINI ---
                if (ScoreManager.instance != null)
                {
                    ScoreManager.instance.SimpanSkor();
                }
                // ---------------------------------------

                CariDanPindahLevel();
            }
        }
    }

    void Menang()
    {
        // 1. Matikan Musik Background
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.MatikanMusik();
        }

        // 2. Mainkan Suara Level Complete
        if (SFXManager.instance != null)
        {
            SFXManager.instance.MainkanLevelComplete();
        }

        // 3. Munculkan panel
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        // Pause Game Biar Musuh Diam
        Time.timeScale = 0f;
    }

    public void PindahKeLevelBerikutnya()
    {
        // 1. Wajib balikin waktu jadi 1 biar animasi Fade bisa jalan
        Time.timeScale = 1f;

        // 2. Simpan Skor sebelum pindah
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.SimpanSkor();
        }

        // --- BAGIAN INI SUDAH DIHAPUS ---
        // Kita HAPUS perintah menyalakan musik disini.
        // Biar pas transisi hening, gak kaget ada suara musik nyala lagi.

        // if (BackgroundMusic.instance != null)
        // {
        //    BackgroundMusic.instance.NyalakanMusik(); 
        // }
        // --------------------------------

        // 3. Panggil LevelLoader buat transisi Fade Out
        CariDanPindahLevel();
    }

    void CariDanPindahLevel()
    {
        LevelLoader loader = FindObjectOfType<LevelLoader>();

        if (loader != null)
        {
            loader.LoadNextLevel(namaSceneSelanjutnya);
        }
        else
        {
            SceneManager.LoadScene(namaSceneSelanjutnya);
        }
    }
}