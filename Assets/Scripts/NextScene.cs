using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public int sceneBuildIndex;
 
    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
