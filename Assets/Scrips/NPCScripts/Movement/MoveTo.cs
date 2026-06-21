using UnityEngine;
using System.Collections.Generic;

public class MoveTo : MonoBehaviour
{
    public Pathfinding pathfinding;

    private static List<MoveTo> moveNPC = new List<MoveTo>();

    public NPCStats Stats;

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

    public static void NPCMoveTO(Vector3 position, int npcID)
    {
        foreach (var npc in moveNPC)
        {
            if (npc.Stats.NPCid == npcID)
            {
                if (MoveNPCToWork.instance.nextPositionToWalkTo == position)
                {
                    Debug.Log("NPC with id " + npc.Stats.NPCid + " is moving to: " + position);
                    npc.findEntringPoint(position);
                }
            // Here you would add the logic to move your NPC to the specified position
            }
        }
    }

    void findEntringPoint(Vector3 pos)
    {
        Vector3 testPos = new Vector3(pos.x, pos.y +2f, 0);
        if (IsPosOccupide.Instance.CheckIfPosIsOccupide(testPos))
        {
            MoveNPCToPosition(testPos);
        }
        else
        {
            Vector3 testPos2 = new Vector3(pos.x +1f, pos.y +2f, 0);
            if (IsPosOccupide.Instance.CheckIfPosIsOccupide(testPos2))
            {
                MoveNPCToPosition(testPos2);
            }
            else
            {
                Vector3 testPos3 = new Vector3(pos.x, pos.y -1f, 0);
                if (IsPosOccupide.Instance.CheckIfPosIsOccupide(testPos3))
                {
                    MoveNPCToPosition(testPos3);
                }
                else
                {
                    Vector3 testPos4 = new Vector3(pos.x +1f, pos.y -1f, 0);
                    if (IsPosOccupide.Instance.CheckIfPosIsOccupide(testPos4))
                    {
                        MoveNPCToPosition(testPos4);
                    }
                    else
                    {
                        MoveNPCToPosition(testPos);
                    }
                }
            }
            // Here you would add logic to find an alternative position if the target is occupied
        }
    }

    void MoveNPCToPosition(Vector3 position)
    {
        pathfinding.SetGoalPosition(position);
    }

    
}
