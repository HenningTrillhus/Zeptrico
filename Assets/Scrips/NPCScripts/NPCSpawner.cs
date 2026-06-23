using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPCprefab; // Assign your NPC prefab in the Inspector
    public Vector3 spawnPosition; // Assign the spawn position in the Inspector

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject spawnedObject = Instantiate(NPCprefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
