using UnityEngine;
using System.Collections.Generic;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;

    private int Xmin = 0;
    private int Xmax = 100;
    private int XCapMin = 35;
    private int XCapMax = 65;

    private int Ymin = 0;
    private int Ymax = 100;
    private int YCapMin = 35;
    private int YCapMax = 65;

    List<Vector3> treePositions = new List<Vector3>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTrees();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnTrees()
    {
        int treeCount = Random.Range(200, 250);
        for (int i = 0; i < treeCount; i++)
        {
            float xPos = Mathf.RoundToInt(Random.Range(Xmin, Xmax))+0.5f;
            float yPos = Mathf.RoundToInt(Random.Range(Ymin, Ymax))+0.5f;
            if (treePositions.Contains(new Vector3(xPos, yPos, 0)) 
            || treePositions.Contains(new Vector3(xPos+1, yPos, 0))
            || treePositions.Contains(new Vector3(xPos, yPos+1, 0))
            || treePositions.Contains(new Vector3(xPos, yPos+1, 0))
            || treePositions.Contains(new Vector3(xPos-1, yPos+1, 0))
            || treePositions.Contains(new Vector3(xPos-1, yPos, 0))
            || treePositions.Contains(new Vector3(xPos-1, yPos-1, 0))
            || treePositions.Contains(new Vector3(xPos, yPos-1, 0))
            || treePositions.Contains(new Vector3(xPos+1, yPos-1, 0)))
            {
                // Skip if a tree already exists at this position
                i--;
                continue;
            }
            if (xPos > XCapMin && xPos < XCapMax && yPos > YCapMin && yPos < YCapMax)
            {
                // Skip spawning trees in the central area
                i--;
                continue;
            }

            Vector3 spawnPosition = new Vector3(xPos, yPos, 0);
            treePositions.Add(spawnPosition);
            Instantiate(treePrefab, spawnPosition, Quaternion.identity);
            // Instantiate your tree prefab at spawnPosition
        }
    }
}
