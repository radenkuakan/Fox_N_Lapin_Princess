using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Pengaturan Panel Options")]
    // Masukkan GameObject Panel Options ke sini lewat Inspector
    public GameObject optionsPanel;

    // ---------------------------------------------------------
    // FUNGSI 1: PINDAH SCENE DINAMIS
    // Perhatikan ada tulisan (string namaScene) di dalam kurung.
    // Ini artinya Unity akan minta kita mengetik nama scene-nya nanti di tombol.
    // ---------------------------------------------------------
    public void PindahKeScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    // ---------------------------------------------------------
    // FUNGSI 2: BUKA/TUTUP OPTIONS
    // Fungsi ini akan menyalakan/mematikan panel options
    // ---------------------------------------------------------
    public void BukaOptions()
    {
        // Aktifkan panel options
        optionsPanel.SetActive(true);
    }

    public void TutupOptions()
    {
        // Matikan panel options (biasanya dipasang di tombol "Back" di dalam panel)
        optionsPanel.SetActive(false);
    }

    // ---------------------------------------------------------
    // FUNGSI 3: KELUAR GAME
    // ---------------------------------------------------------
    public void KeluarGame()
    {
        Debug.Log("Keluar Game...");
        Application.Quit();
    }
}
