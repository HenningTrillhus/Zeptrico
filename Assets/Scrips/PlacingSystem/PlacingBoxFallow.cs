using UnityEngine;
using UnityEngine.InputSystem;

public class PlacingBoxFallow : MonoBehaviour
{
    private Camera cam;
    public bool isPlacing = true;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        gameObject.SetActive(isPlacing);
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);

        Vector3 snappedPos = new Vector3(
            Mathf.Round(worldPos.x),
            Mathf.Round(worldPos.y),
            0
        );

        transform.position = snappedPos;
    }
}