using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Left Click
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse 0 - Left Click");


            // Gets the Mouse Position
            // (0, 0) at the bottom left
            // (width, height) at the top right
            Debug.Log(Input.mousePosition);


            // ScreenToWorldPoint to get the Wolrd Coordinates
            // This would be needed to for example spawn GameObject at the mouse position
            Debug.Log("World Point: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));


            // ScreenToViewportPoint is the (normalized) size of the window
            // (0, 0) at the bottom left and (1, 1) at the top right
            Debug.Log("Viewport Point: " + Camera.main.ScreenToViewportPoint(Input.mousePosition));

        }

        // Right Click
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse 0 - Right Click");
        }

        // Middle Click
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Mouse 0 - Middle Click");
        }
    }
}
