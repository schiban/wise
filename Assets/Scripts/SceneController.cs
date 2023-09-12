using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*
    FINISH POINT

    [SerializedField] bool goNextLevel;
    [SerializedFiled] string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (goNextLevel)
            {
                SceneControler.instance.NextLevel();
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }
        }
    }
    */
    
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene (string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
