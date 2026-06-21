using UnityEngine;

public class SelectWorkers : MonoBehaviour
{
    public GameObject workerSelectionPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        CanvasLogic.instance.openShowFarmDisplay();
        MoveNPCToWork.instance.nextPositionToWalkTo = transform.position; // Set the position for the NPC to walk to
    }
}
