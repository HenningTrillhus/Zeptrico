using UnityEngine;
using UnityEngine.InputSystem;

public class PlacingBuilding : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildingManager.Instance.isPlacing && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Ensure the z-coordinate is set to 0 for 2D
            placeBuilding(FixMousePosition(mousePosition));
        }
    }

    Vector3 FixMousePosition(Vector3 mousePos)
    {
        Vector3 snappedPos = new Vector3(
            Mathf.Round(mousePos.x) + 0.5f,
            Mathf.Round(mousePos.y) + 0.5f,
            0
        );

        transform.position = snappedPos;
        return snappedPos;
    }

    void placeBuilding(Vector3 position)
    {
        int baseX = (int)position.x;
        int baseY = (int)position.y;
        
        if (IsPosOccupide.Instance.CheckIfPosIsOccupide(position))
        {
            GameObject newBuilding = Instantiate(BuildingSpriteDataBase.Instance.FarmPrefab, position, Quaternion.identity);
            for (int i = 0; i < BuildingManager.Instance.buildingHight; i++)
            {
                for (int j = 0; j < BuildingManager.Instance.buildingWidth; j++)
                {
                    occupiedSpaceLogic.Instance.OccupyTile(new Vector2Int(baseX + i, baseY + j), newBuilding);
                }
            }
            BuildingManager.Instance.isPlacing = false;
        }
    }
}
