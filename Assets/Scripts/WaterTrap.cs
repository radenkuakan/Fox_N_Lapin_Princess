using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrap : MonoBehaviour
{
    // Kita butuh akses ke script manager tadi
    public GameOverManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Kalau yang masuk air adalah Player
        if (collision.CompareTag("Player"))
        {
            // Panggil fungsi mati
            gameManager.PlayerMati();
        }
    }
}
