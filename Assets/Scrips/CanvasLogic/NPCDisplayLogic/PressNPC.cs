using UnityEngine;
using UnityEngine.UI;

public class PressNPC : MonoBehaviour
{
    static public PressNPC instance;

    public NPCManager.NPC npc;
    public GameObject interactButton;

    public Vector3 nextPositionToWalkTo; 

    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Setup(NPCManager.NPC npcData)
    {
        npc = npcData;
        interactButton.GetComponent<Button>().onClick.AddListener(OnInteractClicked);
    }

    private void OnInteractClicked()
    {
        Debug.Log("Interacting with " + npc.name);
        if (ShowNPCs.instance.forWorkerPick)
        {
            // Handle worker selection logic here
            Debug.Log("Selected " + npc.name + " for work!");
            MoveNPCToWork.instance.makeNPCMoveToWork(npc.id);
        }
        else
        {
            // Handle regular interaction logic here
            Debug.Log("show info for " + npc.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
