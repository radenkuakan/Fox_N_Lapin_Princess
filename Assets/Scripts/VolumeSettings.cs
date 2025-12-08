using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // WAJIB ADA: Biar skrip kenal apa itu "Slider"

public class VolumeSettings : MonoBehaviour
{
    public Slider sliderVolume;

    void Start()
    {
        // Cek apakah ada BackgroundMusic?
        if (BackgroundMusic.instance != null)
        {
            // Ambil volume asli yang sedang aktif di BackgroundMusic
            // Jadi posisi slider akan mengikuti volume musik yang sebenarnya
            sliderVolume.value = BackgroundMusic.instance.GetComponent<AudioSource>().volume;
        }
    }

    // Fungsi ini akan dipanggil otomatis saat Slider digeser
    public void UbahVolume(float nilai)
    {
        // Lapor ke Bos Musik (BackgroundMusic) untuk ganti volume
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.AturBesarSuara(nilai);
        }
    }
}
