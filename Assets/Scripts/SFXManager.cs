using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [Header("Sumber Suara")]
    public AudioSource audioSource;

    [Header("Koleksi Kaset (Audio Clip)")]
    public AudioClip clickSound;  // Suara Tombol
    public AudioClip jumpSound;   // Suara Lompat
    public AudioClip collectSound; // Suara Ambil Item (BARU)
    public AudioClip gameOverSound; // --- BARU ---
    public AudioClip levelCompleteSound; // --- BARU ---

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MainkanKlik()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void MainkanJump()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound, 3f); // Angka 3f ini volume boost (opsional)
        }
    }

    // --- FUNGSI BARU ---
    public void MainkanCollect()
    {
        if (collectSound != null)
        {
            // Mainkan suara. Kamu bisa atur volumenya (misal 1f atau 0.8f)
            audioSource.PlayOneShot(collectSound, 2f);
        }
    }
    // --- FUNGSI BARU ---
    public void MainkanGameOver()
    {
        if (gameOverSound != null)
        {
            // Mainkan sekali saja
            audioSource.PlayOneShot(gameOverSound, 1f);
        }
    }

    // --- FUNGSI BARU ---
    public void MainkanLevelComplete()
    {
        if (levelCompleteSound != null)
        {
            // Mainkan suara kemenangan
            audioSource.PlayOneShot(levelCompleteSound, 1f);
        }
    }


}