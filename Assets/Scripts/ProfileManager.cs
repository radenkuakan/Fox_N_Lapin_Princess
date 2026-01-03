using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProfileManager : MonoBehaviour
{
    [Header("Komponen UI")]
    public TMP_InputField inputFieldNama;
    public string namaSceneMenu = "Main_Menu";

    [Header("Tirai Penutup")]
    public GameObject layarHitamPenutup;

    // --- [BARU] Variabel untuk Teks Merah ---
    [Header("Peringatan Error")]
    public GameObject teksPeringatan; // Tarik objek TeksPeringatan ke sini
    // ----------------------------------------

    void Start()
    {
        // ... (Bagian Start biarkan sama seperti sebelumnya) ...
        if (PlayerPrefs.HasKey("NamaPlayer"))
        {
            PindahKeMenu();
        }
        else
        {
            if (layarHitamPenutup != null)
            {
                layarHitamPenutup.SetActive(false);
            }
        }
    }

    public void SimpanDanLanjut()
    {
        string nama = inputFieldNama.text;

        // --- CEK APAKAH KOSONG? ---
        if (string.IsNullOrEmpty(nama))
        {
            Debug.Log("Nama tidak boleh kosong!");

            // [BARU] Nyalakan Teks Peringatan di Layar HP
            if (teksPeringatan != null)
            {
                teksPeringatan.SetActive(true);

                // (Opsional) Kalau punya SFX Error/Game Over, bunyikan disini
                // if (SFXManager.instance != null) SFXManager.instance.MainkanGameOver(); 
            }

            return; // Stop, jangan lanjut ke bawah
        }

        // Kalau lolos (ada namanya), simpan dan pindah
        PlayerPrefs.SetString("NamaPlayer", nama);
        PlayerPrefs.Save();

        PindahKeMenu();
    }

    void PindahKeMenu()
    {
        LevelLoader loader = FindObjectOfType<LevelLoader>();
        if (loader != null)
        {
            loader.LoadNextLevel(namaSceneMenu);
        }
        else
        {
            SceneManager.LoadScene(namaSceneMenu);
        }
    }
}