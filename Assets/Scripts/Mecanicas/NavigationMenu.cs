using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationMenu : MonoBehaviour
{
    public int NivelActual;

    public void PlayGame()
    {
        SceneManager.LoadScene(NivelActual+1);

    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }
}
