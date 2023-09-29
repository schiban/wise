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

        // Verificação da existência dos inimigos
        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                allEnemiesInactive = false;
                break;
            }
        }

        // Se todos os inimigos foram eliminados
        if (allEnemiesInactive)
        {
            Victory();
        }

        if (Input.GetKey(KeyCode.P) && !introUI.activeSelf && !pauseMenuUI.activeSelf && !victoryUI.activeSelf && !exitUI.activeSelf)
        {
            Pause();
        }

        if (Input.GetKey(KeyCode.Escape) && pauseMenuUI.activeSelf)
        {
            Resume();
        }

        if(Input.GetKey(KeyCode.Escape) && !pauseMenuUI.activeSelf && exitUI.activeSelf)
        {
            Pause();
        }
    }

    public void Pause()
    {
        exitUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
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
        SceneManager.LoadSceneAsync(5);
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
