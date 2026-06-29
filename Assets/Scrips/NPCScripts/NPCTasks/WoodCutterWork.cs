using UnityEngine;
using System.Linq;

public class WoodCutterWork : MonoBehaviour
{
    public string buildingType = "WoodCutter";

    private bool isWorking = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCStats npcStats = GetComponent<NPCStats>();
        Pathfinding pathfinding = GetComponent<Pathfinding>();
        if (!isWorking && npcStats != null && npcStats.NPCWorkingBuildingType == "WoodCutter")
        {
            // Logic for the woodcutter's work
            Debug.Log("Woodcutter is working at the " + buildingType);
            findClosestTree();
        }
    }

    public void findClosestTree()
    {
        // Logic to find the closest tree for the woodcutter to work on
        
        Vector3 closestTree = TreeSpawner.Instance.treePositions
        .OrderBy(pos => (pos - transform.position).sqrMagnitude)
        .First();
        Debug.Log("Finding the closest tree for the woodcutter." + closestTree);
        isWorking = true;
        Pathfinding pathfinding = GetComponent<Pathfinding>();
        if (pathfinding != null)
        {
            pathfinding.SetGoalPosition(closestTree, 0); // Assuming 0 is the buildingID for the woodcutter
        }
    }
}
