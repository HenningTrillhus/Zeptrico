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
        
    
        foreach (SpriteRenderer sr in allRenderers)
            sr.enabled = false;
    }
}
