using UnityEngine;
using System.Collections.Generic;

public class MoveTo : MonoBehaviour
{
    public Pathfinding pathfinding;

    private static List<MoveTo> moveNPC = new List<MoveTo>();

    public NPCStats Stats;

    private int nextBuildingID;

    //public static event System.Action allNPCReact;

    void OnEnable()
    {
        moveNPC.Add(this);
    }

    void OnDisable()
    {
        moveNPC.Remove(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NPCMoveTO(Vector3 position, int npcID, int buildingID)
    {
        foreach (var npc in moveNPC)
        {
            if (npc.Stats.NPCid == npcID)
            {
                if (MoveNPCToWork.instance.nextPositionToWalkTo == position)
                {
                    Debug.Log("NPC with id " + npc.Stats.NPCid + " is moving to: " + position);
                    npc.nextBuildingID = buildingID;
                    npc.findEntringPoint(position,BuildingManager.Instance.buildingWidth, BuildingManager.Instance.buildingHight);
                }
            // Here you would add the logic to move your NPC to the specified position
            }
        }
    }


    void findEntringPoint(Vector3 pos, int width, int height)
    {
        Debug.Log("findEntringPoint called at: " + pos + " width: " + width + " height: " + height);

        // Define the full footprint of the object
        // e.g. width=2, height=1 means tiles (0,0) and (1,0) relative to bottomLeft

        // Top row (scans left to right)
        for (int x = 0; x <= width; x++)
        {
            Vector3 tile = new Vector3(pos.x + x, pos.y + height, 0);
            if (!IsPosOccupide.Instance.CheckIfPosIsOccupide(tile)){
                Debug.Log("Found entry point at: " + tile);
                MoveNPCToPosition(tile);
                return;
            }
        }

        // Right side (scans top to bottom)
        for (int y = height - 1; y >= 0; y--)
        {
            Vector3 tile = new Vector3(pos.x + width, pos.y + y, 0);
            if (!IsPosOccupide.Instance.CheckIfPosIsOccupide(tile)){
                Debug.Log("Found entry point at: " + tile);
                MoveNPCToPosition(tile);
                return;
            }
        }

        // Bottom row (scans right to left)
        for (int x = width; x >= -1; x--)
        {
            Vector3 tile = new Vector3(pos.x + x, pos.y - 1, 0);
            if (!IsPosOccupide.Instance.CheckIfPosIsOccupide(tile)){
                Debug.Log("Found entry point at: " + tile);
                MoveNPCToPosition(tile);
                return;
            }
        }

        // Left side (scans bottom to top)
        for (int y = 0; y <= height - 1; y++)
        {
            Vector3 tile = new Vector3(pos.x - 1, pos.y + y, 0);
            if (!IsPosOccupide.Instance.CheckIfPosIsOccupide(tile)){
                Debug.Log("Found entry point at: " + tile);
                MoveNPCToPosition(tile);
                return;
            }
        }

        Debug.LogWarning("No available entry point found for the object at position: " + pos);
    }

    void MoveNPCToPosition(Vector3 position)
    {
        pathfinding.SetGoalPosition(position, nextBuildingID);
    }

    

    
}
