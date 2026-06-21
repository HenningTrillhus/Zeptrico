using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class ShowNPCs : MonoBehaviour
{
    static public ShowNPCs instance;

    public GameObject npcDisplayPrefab;
    public Transform ContainerTransform;

    public bool forWorkerPick = false;


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

    public void ShowNPCDisplay(bool forWorkerPick)
    {
        this.forWorkerPick = forWorkerPick;
        int spawnIndex = 0;
        if (NPCManager.instance.NPCList.Count == 0)
        {
            Debug.LogError("NPCManager empty! No NPCs to display.");
            return;
        }
        NPCManager.instance.NPCList.Sort((a, b) => a.name.CompareTo(b.name));

        foreach (NPCManager.NPC npc in NPCManager.instance.NPCList)
        {
            GameObject npcDisplay = Instantiate(npcDisplayPrefab, ContainerTransform);
            TextMeshProUGUI nameText = npcDisplay.transform.Find("NPCName").GetComponent<TextMeshProUGUI>();
            nameText.text = npc.name;
            TextMeshProUGUI genderText = npcDisplay.transform.Find("NPCGender").GetComponent<TextMeshProUGUI>();
            genderText.text = npc.gender;
            TextMeshProUGUI ageText = npcDisplay.transform.Find("NPCAge").GetComponent<TextMeshProUGUI>();
            ageText.text = npc.age.ToString();
            npcDisplay.SetActive(true);
            PressNPC displayItem = npcDisplay.GetComponent<PressNPC>();
            displayItem.Setup(npc);
            
            RectTransform rect = npcDisplay.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, (-spawnIndex * 350f) + 200f);
            spawnIndex++;
        }
        
        
    }
}
