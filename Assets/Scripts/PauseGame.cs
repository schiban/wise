using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject exitUI;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuScene()
    {
        SceneManager.LoadSceneAsync(5);
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
