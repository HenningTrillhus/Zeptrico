using UnityEngine;
using System.Collections.Generic;

public class TaskManager : MonoBehaviour
{
    public class Task
    {
        public string BuildingName;
        public int buildingID;
        public Vector3 position;

    }

    List<Task> Tasks = new List<Task>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
