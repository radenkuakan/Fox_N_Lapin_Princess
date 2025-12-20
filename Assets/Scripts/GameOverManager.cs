using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Wajib buat Reload Scene

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    // Tarik Panel Game Over ke sini di Inspector
    public GameObject panelGameOver;

    [Header("Nama Scene Menu Utama")]
    public string namaSceneMenu = "Main_Menu";

    // Nama fungsi ini WAJIB "PlayerMati" sesuai request kamu
    public void PlayerMati()
    {
        StartCoroutine(ProsesKematian());
    }

    IEnumerator ProsesKematian()
    {
        // 1. Cari Player dan mainkan animasi Hurt
        PlayerMovement playerScript = FindObjectOfType<PlayerMovement>();
        if (playerScript != null)
        {
            playerScript.TriggerHurt();
        }

        // 2. Matikan Musik & SFX
        if (BackgroundMusic.instance != null) BackgroundMusic.instance.MatikanMusik();
        if (SFXManager.instance != null) SFXManager.instance.MainkanGameOver();

        // 3. TUNGGU SEBENTAR
        yield return new WaitForSeconds(0.5f);

        // 4. Munculkan panel & hentikan waktu
        if (panelGameOver != null) panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    // --- FUNGSI TOMBOL "COBA LAGI" (SUDAH DIPERBAIKI) ---
    public void CobaLagi()
    {
        Time.timeScale = 1f; // Waktu jalan lagi

        // --- BAGIAN YANG DIHAPUS ---
        // ScoreManager.instance.ResetScore(); <--- JANGAN DI-RESET DISINI!
        // Biarkan dia ngeload skor dari save-an terakhir (Level 1).

        // Muat Ulang Level saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi Tombol "KEMBALI KE MENU"
    public void KeMenuUtama()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(namaSceneMenu);
    }
}