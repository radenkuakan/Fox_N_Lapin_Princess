using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        // Jika Klik Kiri Mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Tembak garis laser (Raycast) dari posisi mouse
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // Kalau kena sesuatu
            if (hit.collider != null)
            {
                // Cek apakah yang kena itu punya script 'Bangunan'?
                Bangunan bangunan = hit.collider.GetComponent<Bangunan>();
                if (bangunan != null)
                {
                    bangunan.Interaksi(); // Panggil fungsi Interaksi
                }
            }
        }
    }
}
