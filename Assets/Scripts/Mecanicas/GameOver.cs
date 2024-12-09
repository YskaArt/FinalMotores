using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    private PlayerLogicAnimation playerLogic;
    private ThirdPersonCamera cameraScript;
    

    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogicAnimation>();
        cameraScript = FindObjectOfType<ThirdPersonCamera>();
        if (gameOverUI != null) gameOverUI.SetActive(false);
    }

    public void TriggerGameOver()
    {
        
        if (gameOverUI != null) gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        if (playerLogic != null) playerLogic.enabled = false;
        if (cameraScript != null) cameraScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

   
}
