using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    public int placingBuildingid = 0;
    public string placingBuildingName = "";
    public bool isPlacing = false;
    public int buildingHight = 2;
    public int buildingWidth = 2;

    public class building
    {
        public string BuildingName;
        public int buildingID;
        public Vector3 position;
        public int width;
        public int height;
    }

    public List<building> buildings = new List<building>();

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
        placingBuildingName = "Farm";
        isPlacing = true;
        placingBuildingid = buildings.Count > 0 ? buildings.Max(b => b.buildingID) + 1 : 1;
        buildingHight = 2;
        buildingWidth = 2;
    }

    public void PlaceWoodCutter()
    {
        placingBuildingName = "WoodCutter";
        isPlacing = true;
        placingBuildingid = buildings.Count > 0 ? buildings.Max(b => b.buildingID) + 1 : 1;
        buildingHight = 3;
        buildingWidth = 3;
    }
}
