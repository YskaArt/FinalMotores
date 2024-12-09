using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    private GameOver gameOverManager;

    void Start()
    {
        gameOverManager = FindObjectOfType<GameOver>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            
                gameOverManager.TriggerGameOver();
            
        }
    }
}
