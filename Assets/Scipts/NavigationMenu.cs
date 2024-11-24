using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationMenu : MonoBehaviour
{
    [SerializeField] private int NivelActual;

    public void PlayGame()
    {
        SceneManager.LoadScene(NivelActual+1);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }
}
