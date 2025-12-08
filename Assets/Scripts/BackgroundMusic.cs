using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton Pattern (Hanya boleh ada 1 Speaker di game)
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject); // Jimat Anti-Hancur
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Fungsi canggih untuk ganti lagu
    public void GantiLagu(AudioClip laguBaru)
    {
        // 1. Jika tidak ada lagu yang diminta (kosong), matikan musik
        if (laguBaru == null)
        {
            audioSource.Stop();
            return;
        }

        // 2. Jika lagu yang diminta SAMA dengan yang sedang main, JANGAN ganti (Biar seamless)
        if (audioSource.clip == laguBaru && audioSource.isPlaying)
        {
            return; // Keluar, jangan lakukan apa-apa
        }

        // 3. Jika lagu beda, ganti kasetnya dan mainkan
        audioSource.clip = laguBaru;
        audioSource.Play();
    }

    // Fungsi untuk mengubah volume Audio Source
    // Angkanya dari 0.0 (hening) sampai 1.0 (full)
    public void AturBesarSuara(float volume)
    {
        audioSource.volume = volume;
    }

    // Fungsi untuk mematikan musik sementara
    public void MatikanMusik()
    {
        audioSource.Stop();
    }

    // Fungsi untuk menyalakan musik lagi
    public void NyalakanMusik()
    {
        audioSource.Play();
    }
}
