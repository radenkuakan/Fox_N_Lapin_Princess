using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendaPusaka : MonoBehaviour
{
    public GameObject panelSoal; // Kotak UI Kuis yang akan dimunculkan


    private void OnMouseDown()
    {
        Debug.Log("Angklung Diklik!");
        panelSoal.SetActive(true); // Munculkan panel soal
    }
}
