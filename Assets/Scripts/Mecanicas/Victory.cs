using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] private float checkInterval = 1f;
    public NavigationMenu menu;
    private float timer = 0f;

    void Update()
    {
        
        timer += Time.deltaTime;

        // Chequea a intervalos definidos
        if (timer >= checkInterval)
        {
            timer = 0f; // Reinicia el temporizador
            CheckForEnemies();
        }
    }

    void CheckForEnemies()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Si no hay enemigos, cambia a la pantalla de victoria
        if (enemies.Length == 0)
        {
            LoadVictoryScene();
        }
    }

    void LoadVictoryScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("No hay enemigos. Cargando la pantalla de victoria...");
        SceneManager.LoadScene(menu.NivelActual + 1);
    }
}
