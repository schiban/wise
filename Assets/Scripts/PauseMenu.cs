using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject introUI, pauseMenuUI, victoryUI, exitUI;
    public List<GameObject> enemies;
    private bool allEnemiesInactive;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        allEnemiesInactive = true;

        // Check if any enemy is active
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                allEnemiesInactive = false;
                break; // Exit the loop as soon as an active enemy is found
            }
        }

        // If all enemies are inactive, call Victory()
        if (allEnemiesInactive)
        {
            Victory();
        }

        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        if (Input.GetKey(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Victory()
    {
        Time.timeScale = 0;
        victoryUI.SetActive(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        introUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ResumeMainMenu()
    {
        exitUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void MainMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void CreditScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void ExitScene()
    {
        pauseMenuUI.SetActive(false);
        exitUI.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
