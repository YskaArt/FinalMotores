using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Activate : MonoBehaviour
{
    
    public List<GameObject> enemies; // Lista de enemigos a activar

    
    public Text enemiesText; // Texto en el Canvas para mostrar el conteo de enemigos
    public GameObject EnemyText;
    private int totalEnemies;
    private int remainingEnemies;
    public Animator DoorLevel1;

    private void Start()
    {
        EnemyText.SetActive(false);
        
        totalEnemies = enemies.Count;
        remainingEnemies = totalEnemies;
        UpdateEnemiesText();
        


        // Asegúrate de que los enemigos estén desactivados al inicio
        foreach (var enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            // Activa los enemigos
            foreach (var enemy in enemies)
            {
                enemy.SetActive(true);
            }

            EnemyText.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void EnemyDefeated()
    {
       
        remainingEnemies--;

        
        UpdateEnemiesText();

        
        if (remainingEnemies <= 0)
        {
            Debug.Log("Todos los enemigos han sido derrotados!");
            DoorLevel1.SetBool("OpenDoor", true);
        }
    }

    private void UpdateEnemiesText()
    {
        // Actualiza el texto con el conteo actual
        enemiesText.text = $"Enemigos Totales: {totalEnemies}\nEnemigos Restantes: {remainingEnemies}";
    }

}


