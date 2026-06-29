using UnityEngine;

public class BuildingSpriteDisplay : MonoBehaviour
{
    private PlacingBoxFallow placingBoxFallow;
    public static BuildingSpriteDisplay Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        placingBoxFallow = GetComponent<PlacingBoxFallow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildingManager.Instance.isPlacing)
        {
            Sprite sprite = BuildingSpriteDataBase.Instance.GetSprite(BuildingManager.Instance.bulldingTypeID);
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    public void checkIfPosIsOccupide(Vector3 pos)
    {
        for (int i = 0; i < BuildingManager.Instance.buildingHight; i++)
        {
            for (int j = 0; j < BuildingManager.Instance.buildingWidth; j++)
            {
                Vector2Int tilePos = new Vector2Int((int)pos.x + i, (int)pos.y + j);
                if (occupiedSpaceLogic.Instance.IsOccupied(tilePos))
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    return;
                }
            }
        }
        GetComponent<SpriteRenderer>().color = Color.green;
    }
}
