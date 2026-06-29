using UnityEngine;

public class AtWorkSite : MonoBehaviour
{
    private Pathfinding pathfinding;

    private SpriteRenderer[] allRenderers;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allRenderers = GetComponentsInChildren<SpriteRenderer>();

        pathfinding = GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtWork(int buildingID)
    {
        // Logic for when the NPC is at the work site
        Debug.Log("NPC has arrived at the work site for building ID: " + buildingID);
        // You can add more logic here, such as starting work, playing animations, etc.
        NPCStats npcStats = GetComponent<NPCStats>();
        string buildingType = BuildingManager.Instance.getBuildingTypeByID(buildingID);
        
        if (npcStats != null)
        {
            npcStats.NPCWorkingBuildingType = buildingType; // Set the building type the NPC is working at
            Debug.Log("NPC is working at building type: " + npcStats.NPCWorkingBuildingType);
        }

        foreach (SpriteRenderer sr in allRenderers)
            sr.enabled = false;
    }
}
