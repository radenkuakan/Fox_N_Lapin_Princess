using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panelGameOver;

    [Header("Player Settings")]
    public Transform player;       // Objek Player (Rubah)
    public Transform respawnPoint; // Titik Respawn (Objek Kosong tadi)

    // Fungsi dipanggil saat Player kena air/musuh
    public void PlayerMati()
    {
        // 1. Matikan Musik Background (Biar hening/dramatis)
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.MatikanMusik();
        }

        // 2. Mainkan Suara Game Over (Jeng jeng jeng!)
        if (SFXManager.instance != null)
        {
            SFXManager.instance.MainkanGameOver();
        }

        // 3. Munculkan panel & Hentikan waktu
        panelGameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    // Fungsi untuk Tombol "Coba Lagi"
    public void RespawnUlang()
    {
        Time.timeScale = 1f;

        // 1. Nyalakan Musik Background Lagi
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.NyalakanMusik();
        }

        // 2. Pindahkan Player & Reset Velocity
        player.position = respawnPoint.position;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        // 3. Sembunyikan panel
        panelGameOver.SetActive(false);
    }

    // Fungsi untuk Tombol "Keluar"
    public void KeMenuUtama()
    {
        Time.timeScale = 1f; // Selalu normalkan waktu sebelum pindah scene!
        SceneManager.LoadScene("Main_Menu");
    }
}
