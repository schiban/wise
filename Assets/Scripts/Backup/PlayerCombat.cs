using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jab();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cross();
        }
    }

    void Jab()
    {
        // Play an jab animation
        // Detect
    }

    void Cross()
    {
        // Play an cross animation
        // Detect
    }
}
