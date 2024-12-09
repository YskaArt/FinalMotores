using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private bool isPaused = false;
    private PlayerLogicAnimation playerLogic;
    private ThirdPersonCamera cameraScript;

    void Start()
    {
        playerLogic = FindObjectOfType<PlayerLogicAnimation>();
        cameraScript = FindObjectOfType<ThirdPersonCamera>();
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        if (playerLogic != null) playerLogic.enabled = true;
        if (cameraScript != null) cameraScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        if (playerLogic != null) playerLogic.enabled = false;
        if (cameraScript != null) cameraScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


}
