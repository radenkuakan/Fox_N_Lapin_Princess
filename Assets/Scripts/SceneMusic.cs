using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    [Header("Pilih Lagu untuk Scene Ini")]
    public AudioClip laguSceneIni; // Tarik file lagu ke sini lewat Inspector

    void Start()
    {
        // Saat scene mulai, lapor ke Speaker Abadi minta putar lagu ini
        if (BackgroundMusic.instance != null)
        {
            BackgroundMusic.instance.GantiLagu(laguSceneIni);
        }
    }
}
