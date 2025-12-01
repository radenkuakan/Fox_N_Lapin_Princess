using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    // Fungsi ini dipanggil untuk pindah ke scene berdasarkan nama
    public void PindahKe(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }
}
