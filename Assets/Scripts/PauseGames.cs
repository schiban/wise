using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGames : MonoBehaviour
{
    public GameObject pauseMenuUI, exitUI;

    void Update()
    {
        if (Input.GetKey(KeyCode.P) && !pauseMenuUI.activeSelf && !exitUI.activeSelf)
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuScene()
    {
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
