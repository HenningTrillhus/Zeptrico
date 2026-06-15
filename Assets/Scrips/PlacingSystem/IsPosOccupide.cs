using UnityEngine;

public class IsPosOccupide : MonoBehaviour
{
    public static IsPosOccupide Instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfPosIsOccupide(Vector3 pos)
    {
        bool areaFree = true;
        int baseX = (int)pos.x;
        int baseY = (int)pos.y;
        for (int x = 0; x < BuildingManager.Instance.buildingHight; x++)
        {
            for (int y = 0; y < BuildingManager.Instance.buildingWidth; y++)
            {
                if (OcupideSpace.Instance.IsOccupied(new Vector2Int(baseX + x, baseY + y)))
                {
                    areaFree = false;
                    Debug.Log("Tile is already occupied!");
                    break;
                }
            }
        }
        return areaFree;
    }
}
