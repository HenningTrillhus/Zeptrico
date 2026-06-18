using UnityEngine;
using UnityEngine.InputSystem;

public class PlacingBoxFallow : MonoBehaviour
{
    private Camera cam;
    private SpriteRenderer spriteRenderer;

    private Vector3 lastSnappedPos;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        spriteRenderer.enabled = BuildingManager.Instance.isPlacing;
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);

        Vector3 snappedPos = new Vector3(
            Mathf.Round(worldPos.x+0.1f),
            Mathf.Round(worldPos.y+0.5f),
            0
        );

        transform.position = snappedPos;

        if (snappedPos != lastSnappedPos)
        {
            lastSnappedPos = snappedPos;
            if (BuildingManager.Instance.isPlacing)
            {
                BuildingSpriteDisplay.Instance.checkIfPosIsOccupide(snappedPos);
            }
        }
    }
}