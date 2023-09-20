using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Main Menu Components")]
    public GameObject introUI;
    public GameObject mainMenuUI;
    public GameObject helpUI;
    public GameObject creditsUI;
    public GameObject exitUI;
    public GameObject loaderUI;
    public Slider progressSlider;

    public void MainMenuScene(int index)
    {
        introUI.SetActive(false);
        helpUI.SetActive(false);
        creditsUI.SetActive(false);
        exitUI.SetActive(false);
        
        mainMenuUI.SetActive(true);
    }

    public void PlayScene(int index)
    {
        StartCoroutine(LoadScene_Coroutine(index));
    }

    public void HelpScene(int index)
    {
        mainMenuUI.SetActive(false);
        helpUI.SetActive(true);
    }

    public void CreditsScene(int index)
    {
        mainMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void ExitScene(int index)
    {
        mainMenuUI.SetActive(false);
        exitUI.SetActive(true);
    }

    public void ExitGame(int index)
    {
        Application.Quit();
    }

    public IEnumerator LoadScene_Coroutine(int index)
    {
        progressSlider.value = 0;
        loaderUI.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
