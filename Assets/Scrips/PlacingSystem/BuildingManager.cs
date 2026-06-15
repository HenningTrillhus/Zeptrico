using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    public int placingBuildingid = 0;
    public bool isPlacing = false;
    public int buildingHight = 2;
    public int buildingWidth = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceFarm()
    {
        isPlacing = true;
        placingBuildingid = 0;
        buildingHight = 2;
        buildingWidth = 2;
    }
}
