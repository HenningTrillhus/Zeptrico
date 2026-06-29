using System.Collections.Generic;
using UnityEngine;

public class occupiedSpaceLogic : MonoBehaviour
{
    public static occupiedSpaceLogic Instance;
    public GameObject occupiedSpacePrefab;

    private bool ocupideTilesVisible = false;

    private Dictionary<Vector2Int, GameObject> occupiedTiles = new Dictionary<Vector2Int, GameObject>();

    public class tile
    {
        public Vector2Int position;
        public GameObject occupant;
    }

    public List<tile> CoveredOccupiedTilesList = new List<tile>();

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
        UpdateCoveredOccupiedTilesList(tilePos, occupant);
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

    private void UpdateCoveredOccupiedTilesList(Vector2Int tilePos, GameObject occupant)
    {
        GameObject tilePrefab = Instantiate(occupiedSpacePrefab, new Vector3(tilePos.x, tilePos.y, 0), Quaternion.identity);
        tile newTile = new tile { position = tilePos, occupant = tilePrefab };
        CoveredOccupiedTilesList.Add(newTile);
        tilePrefab.SetActive(ocupideTilesVisible);
        
    }

    public void changeVisibilityOfOccupiedTiles()
    {
        ocupideTilesVisible = !ocupideTilesVisible;
        foreach (var tile in CoveredOccupiedTilesList)
        {
            if (tile.occupant != null)
            {
                tile.occupant.SetActive(ocupideTilesVisible);
            }
        }
    }
}