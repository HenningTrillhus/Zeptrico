using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float zoomSpeed = 2f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float x = 0f;
        float y = 0f;

        if (Keyboard.current.dKey.isPressed) x =  1f;
        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.wKey.isPressed) y =  1f;
        if (Keyboard.current.sKey.isPressed) y = -1f;

        float speed = Keyboard.current.leftShiftKey.isPressed ? sprintSpeed : moveSpeed;

        Vector3 move = new Vector3(x, y, 0);
        transform.position += move * speed * Time.deltaTime;

        // Zoom
        float scroll = Mouse.current.scroll.ReadValue().y;
        cam.orthographicSize -= scroll * zoomSpeed;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2f, 20f);
    }
}