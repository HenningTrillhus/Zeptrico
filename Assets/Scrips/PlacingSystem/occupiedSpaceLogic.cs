using System.Collections.Generic;
using UnityEngine;

public class occupiedSpaceLogic : MonoBehaviour
{
    public static occupiedSpaceLogic Instance;

    private Dictionary<Vector2Int, GameObject> occupiedTiles = new Dictionary<Vector2Int, GameObject>();

    void Awake()
    {
        Instance = this;
    }

    public bool IsOccupied(Vector2Int tilePos)
    {
        return occupiedTiles.ContainsKey(tilePos);
    }

    public void OccupyTile(Vector2Int tilePos, GameObject occupant)
    {
        occupiedTiles[tilePos] = occupant;
    }

    public void FreeTile(Vector2Int tilePos)
    {
        occupiedTiles.Remove(tilePos);
    }

    public GameObject GetOccupant(Vector2Int tilePos)
    {
        occupiedTiles.TryGetValue(tilePos, out GameObject occupant);
        return occupant;
    }
}