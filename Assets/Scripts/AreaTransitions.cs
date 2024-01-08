using UnityEngine;

public class AreaTransitions : MonoBehaviour
{
    [Header("Components")]
    private CameraController cam;
    private Camera mainCamera;

    [Header("Camera Settings")]
    public float newOrthographicSize;
    public Vector2 newMinPosition;
    public Vector2 newMaxPosition;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.minPosition = newMinPosition;
            cam.maxPosition = newMaxPosition;
            mainCamera.orthographicSize = newOrthographicSize;
        }
    }
}
