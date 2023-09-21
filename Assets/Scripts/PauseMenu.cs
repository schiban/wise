using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject introUI;
    public GameObject pauseMenuUI;
    public GameObject victoryUI;
    public GameObject exitUI;

    public GameObject enemy, enemy1, enemy2, enemy3, enemy4, enemy5, enemy6;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (enemy.activeSelf == false && enemy1.activeSelf == false && enemy2.activeSelf == false && enemy3.activeSelf == false && enemy4.activeSelf == false && enemy5.activeSelf == false && enemy6.activeSelf == false) 
        {
            Victory();
        }

        if (Input.GetKey(KeyCode.P))
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
        SceneManager.LoadSceneAsync(5);
    }

    public void CreditScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
        // SceneManager.LoadSceneAsync(6);
    }

    public void ExitScene(int index)
    {
        pauseMenuUI.SetActive(false);
        exitUI.SetActive(true);
    }

    public void ExitGame(int index)
    {
        Application.Quit();
    }
}
