using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INI ADALAH BASE CLASS (INDUK)
public class Bangunan : MonoBehaviour
{
    public string namaBangunan; // Saung Aki


    public virtual void Interaksi()
    {
        Debug.Log("Kamu mengklik bangunan: " + namaBangunan);
    }
}
