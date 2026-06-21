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
        MoveTo.NPCMoveTO(nextPositionToWalkTo, NPCID);
    }
}
