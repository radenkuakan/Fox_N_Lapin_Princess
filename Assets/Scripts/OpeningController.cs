using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Wajib buat pindah scene

public class OpeningController : MonoBehaviour
{
    [Header("Pengaturan Waktu")]
    public float durasiTampil = 3f; // Mau tampil berapa detik? (Misal 3 detik)
    public string sceneSelanjutnya = "Main_Menu"; // Nama scene tujuan

    void Start()
    {
        // Perintah: "Panggil fungsi PindahScene setelah (durasiTampil) detik"
        Invoke("PindahScene", durasiTampil);
    }

    void PindahScene()
    {
        SceneManager.LoadScene(sceneSelanjutnya);
    }
}
