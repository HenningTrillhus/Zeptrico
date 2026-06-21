using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class WorkerDataBase : MonoBehaviour
{
    public static WorkerDataBase instance;


    public class WorkPlace
    {
        public int id;
        public Vector3 pos;
        public string buildingType;
    }

    public List<WorkPlace> workPlaces = new List<WorkPlace>();


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

    public int getID()
    {
        return workPlaces.Count > 0 ? workPlaces.Max(n => n.id) + 1 : 1;
    }
}
