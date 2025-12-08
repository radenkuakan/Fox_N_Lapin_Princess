using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    // Fungsi ini dipanggil saat tombol ditekan
    public void TekanTombol()
    {
        // Langsung lapor ke "Bos" SFXManager yang sedang aktif (yang abadi)
        if (SFXManager.instance != null)
        {
            SFXManager.instance.MainkanKlik();
        }
    }
}
