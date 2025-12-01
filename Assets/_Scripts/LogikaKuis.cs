using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogikaKuis : MonoBehaviour
{
    public GameObject panelSoal;

    public void JawabanBenar()
    {
        Debug.Log("Jawaban Benar!");

        SceneManager.LoadScene("Desa");
    }

    public void JawabanSalah()
    {
        Debug.Log("Salah, coba lagi.");
        panelSoal.SetActive(false);
    }
}
