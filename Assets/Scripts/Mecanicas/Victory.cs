using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
   
    public NavigationMenu menu;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Cargando la pantalla de victoria...");
            SceneManager.LoadScene(menu.NivelActual + 1);
        }
    }
    
}
