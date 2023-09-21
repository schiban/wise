using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivate : MonoBehaviour
{
    public GameObject player, healthUI;

    IEnumerator Start()
    {
        // Wait for 48,8 seconds
        yield return new WaitForSeconds(48.8f);

        // Activate the GameObject
        player.SetActive(true);
        healthUI.SetActive(true);
    }
}