using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    static public NPCManager instance;

    public class NPC
    {
        public int id;
        public string name;
        public string gender;
        public int age;
    }

    public List<NPC> NPCList = new List<NPC>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNPC(string name, string gender, int age, int id)
    {
        NPC newNPC = new NPC();
        newNPC.id = id;
        newNPC.name = name;
        newNPC.gender = gender;
        newNPC.age = age;
        NPCList.Add(newNPC);
        Debug.Log(newNPC.name + "    id:" + newNPC.id +  " added to NPC Manager!");
    }
}
