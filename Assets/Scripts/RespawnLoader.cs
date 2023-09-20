using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnLoader : MonoBehaviour
{
    public GameObject respawnUI;

    void Start()
    {
        respawnUI.SetActive(false);
    }

    public void RespawnScene(int index)
    {
        respawnUI.SetActive(true);
    }
}
