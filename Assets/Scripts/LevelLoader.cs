using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    // KITA KUNCI WAKTUNYA DISINI.
    // 0.5 detik adalah waktu standar "Sat-Set" (Cepat).
    // Jadi kamu GAK PERLU setting-setting di Inspector lagi.
    private float waktuTungguTetap = 0.5f;

    public void LoadNextLevel(string namaScene)
    {
        StartCoroutine(LoadLevel(namaScene));
    }

    IEnumerator LoadLevel(string namaScene)
    {
        // 1. Mulai animasinya
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }

        // 2. Tunggu sebentar (0.5 detik)
        // Ini memberi waktu supaya layar sempat gelap dulu
        yield return new WaitForSeconds(waktuTungguTetap);

        // 3. Load Scene di Background (Async)
        // Ini rahasianya biar gak terasa "Ngelag/Bengong" saat pindah
        SceneManager.LoadSceneAsync(namaScene);
    }
}