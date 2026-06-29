using UnityEngine;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{
    private AtWorkSite atWorkSite;

    private Vector3 GoalPos = new Vector3(58, 60, 0);
    private Vector3 pos;

    //Walkable mapSize
    private int minX = 0;
    private int maxX = 100;
    private int minY = 0;
    private int maxY = 100;

    private List<Vector2Int> currentPath;
    private int pathIndex;
    public float moveSpeed = 1.5f;
    public float rotationSpeed = 10f;

    public bool isMoving = false;

    private bool DoneMoving = true;
    private int nextBuildingID;

    private SpriteRenderer[] allRenderers;



    public class Node
    {
        public Vector2Int Position;
        public bool Walkable;
        public Node Parent;
        public int GCost;
        public int HCost;
        public int FCost => GCost + HCost; // calculated automatically from G and H

        public Node(Vector2Int position, bool walkable)
        {
            Position = position;
            Walkable = walkable;
        }
    }

    List<Node> openSet = new List<Node>();
    HashSet<Node> closedSet = new HashSet<Node>();
    Dictionary<Vector2Int, Node> allNodes = new Dictionary<Vector2Int, Node>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allRenderers = GetComponentsInChildren<SpriteRenderer>();
        atWorkSite = GetComponent<AtWorkSite>();
        pos = transform.position;
        //converting to grid coordinates (no decimals)
        /*Vector2Int posGrid = new Vector2Int((int)pos.x, (int)pos.y);
        Vector2Int goalGrid = new Vector2Int((int)GoalPos.x, (int)GoalPos.y);
        findPath(posGrid, goalGrid);
        pathIndex = 0;*/
    }

    public void SetGoalPosition(Vector3 newGoal, int buildingID)
    {
        DoneMoving = false;
        Debug.Log("SetGoalPosition called with: " + newGoal);
        GoalPos = newGoal;
        nextBuildingID = buildingID;
        Vector2Int posGrid = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        Vector2Int goalGrid = new Vector2Int((int)GoalPos.x, (int)GoalPos.y);
        findPath(posGrid, goalGrid);
        pathIndex = 0;
        foreach (SpriteRenderer sr in allRenderers)
            sr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPath == null || pathIndex >= currentPath.Count){
            isMoving = false;
            if (currentPath != null && pathIndex >= currentPath.Count && !DoneMoving) 
            {
                Debug.Log("Reached the end of the path.");
                DoneMoving = true;
                atWorkSite.AtWork(nextBuildingID);
            }
            return; // no path, or already finished
        }
        
        Vector3 targetWorldPos = new Vector3(currentPath[pathIndex].x, currentPath[pathIndex].y, 0);
        isMoving = true;

        // Calculate direction before moving
        Vector3 direction = (targetWorldPos - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle - 90f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWorldPos) < 0.01f)
        {
            pathIndex++; // reached this tile, move on to the next one
        }
    }

    void findPath(Vector2Int startPos, Vector2Int goalPos)
    {
        openSet.Clear();
        closedSet.Clear();

        Node startNode = GetNode(startPos);
        startNode.GCost = 0;
        startNode.HCost = heuristic(startPos, goalPos);

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            //Looks through open set to find node with lowest F cost, and sets it as current node.
            //basacly looking trough the discovered nodes and find the one closest to the goal, to continue searching from there.
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].FCost < currentNode.FCost)
                {
                    currentNode = openSet[i];
                }
            }

            //move to closed set
            openSet.Remove(currentNode);
            closedSet.Add(currentNode);


            // Check if we reached the goal
            if (currentNode.Position == goalPos)
            {
                currentPath = RetracePath(startNode, currentNode);
                Debug.Log("Path found! Length: " + currentPath.Count);
                /*foreach (var step in currentPath)
                    Debug.Log(step);*/
                break;

            }

            // 4. Check neighbors
            foreach (Node neighbor in GetNeighbors(currentNode))
            {
                //Check if neighbor is walkable and not in closed set, if not, skip it.
                if (!neighbor.Walkable || closedSet.Contains(neighbor))
                    continue;

                int tentativeG = currentNode.GCost + 1; // cost of one step

                if (tentativeG < neighbor.GCost)
                {
                    neighbor.GCost = tentativeG;
                    neighbor.HCost = heuristic(neighbor.Position, goalPos);
                    neighbor.Parent = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }

        }
    }

    //finds neighbors of node and returns list of them
    List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();

        Vector2Int[] directions = new Vector2Int[]
        {
            new Vector2Int(0, 1),   // up
            new Vector2Int(0, -1),  // down
            new Vector2Int(1, 0),   // right
            new Vector2Int(-1, 0)   // left
        };

        foreach (Vector2Int dir in directions)
        {
            //Gets position of node, bassed on direction and current node. 
            Vector2Int neighborPos = node.Position + dir;
            // skip this neighbor entirely, it's off the map
            if (!IsInBounds(neighborPos))continue; 
            //Creats new node with position and walkable status
            Node neighborNode = GetNode(neighborPos);
            //Adds neighbor to list of neighbors
            neighbors.Add(neighborNode);
        }

        return neighbors;
    }

    Node GetNode(Vector2Int pos)
    //Helper function to know when to creat a new neighbore node or when not to.
    {
        //checks if node already exists
        if (allNodes.ContainsKey(pos))
        {
            return allNodes[pos];
        }
        //if node dose not exist creat a new one.
        Node newNode = new Node(pos, isWalkable(pos));
        newNode.GCost = int.MaxValue;
        allNodes[pos] = newNode;
        return newNode;
    }


    int heuristic(Vector2Int pos, Vector2Int goal)
    {
        //Get manhatten distance
        int dx = (int)Mathf.Abs(goal.x - pos.x);
        int dy = (int)Mathf.Abs(goal.y - pos.y);
        return dx + dy;
    }

    int checkTile(Vector2Int pos, Vector2Int goal, int g)
    {
        if (isWalkable(pos))
        {
            //returns F, manhattan distance + amount of steps taken
            return heuristic(pos, goal) + g;
        }
        return 0;
    }

    bool isWalkable(Vector2Int pos)
    {
        return !occupiedSpaceLogic.Instance.IsOccupied(pos);
    }

    bool IsInBounds(Vector2Int pos)
    {
        return pos.x >= minX && pos.x <= maxX && pos.y >= minY && pos.y <= maxY;
    }


    //recreate the path from the goal back to the start to creat the complete path.
    List<Vector2Int> RetracePath(Node startNode, Node endNode)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode.Position);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        return path;
    }
}
