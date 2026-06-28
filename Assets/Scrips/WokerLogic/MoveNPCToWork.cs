using UnityEngine;

public class MoveNPCToWork : MonoBehaviour
{
    public static MoveNPCToWork instance;

    public Vector3 nextPositionToWalkTo;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeNPCMoveToWork(int NPCID)
    {
        MoveTo.NPCMoveTO(nextPositionToWalkTo, NPCID, getBuldingIDFromPos(nextPositionToWalkTo));
    }

    public int getBuldingIDFromPos(Vector3 position)
    {
        foreach (var building in BuildingManager.Instance.buildings)
        {
            if (building.position == position)
            {
                return building.buildingID; // Return the building ID if the position matches
                // You can now use building.buildingID as needed
            }
        }
        return -1; // Return -1 if no building is found at the given position
    }
}
