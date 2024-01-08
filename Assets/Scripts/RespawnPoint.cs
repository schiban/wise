using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RespawnPoint : MonoBehaviour
{
    public GameObject respawnUI;

    void Start()
    {
        respawnUI.SetActive(false);
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RespawnScene()
    {
        respawnUI.SetActive(true);
    }
}
