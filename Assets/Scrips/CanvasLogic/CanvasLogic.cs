using UnityEngine;

public class CanvasLogic : MonoBehaviour
{
    public static CanvasLogic instance;

    public GameObject BuildPanel;
    public GameObject npcDisplayUI;
    public GameObject farmDisplayUI;
    public GameObject woodCutterDisplayUI;

    private bool buildingPanelVisible = false;
    private bool npcDisplayVisible = false;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildPanel.SetActive(false); 
        npcDisplayUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBuildPanel()
    {
        buildingPanelVisible = !buildingPanelVisible;
        BuildPanel.SetActive(buildingPanelVisible);
        
    }

    public void OpenShowNPCDisplay()
    {
        npcDisplayVisible = !npcDisplayVisible;
        npcDisplayUI.SetActive(npcDisplayVisible);
        if (npcDisplayVisible)
        {
            ShowNPCs.instance.ShowNPCDisplay(false);
        }
        else
        {
            // Clear NPC display when hiding
            foreach (Transform child in ShowNPCs.instance.ContainerTransform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void openShowNPCForWorkerPick()
    {
        npcDisplayVisible = !npcDisplayVisible;
        npcDisplayUI.SetActive(npcDisplayVisible);
        ShowNPCs.instance.ShowNPCDisplay(true);
        farmDisplayUI.SetActive(false);
    }

    public void openShowFarmDisplay()
    {
        farmDisplayUI.SetActive(true);
    }

    public void openShowWoodCutterDisplay()
    {
        woodCutterDisplayUI.SetActive(true);
    }

    public void closeBuildPanel()
    {
        buildingPanelVisible = false;
        BuildPanel.SetActive(false);
    }

    public void closeShowNPCDisplay()
    {
        npcDisplayVisible = false;
        npcDisplayUI.SetActive(false);
    }

    public void closeShowFarmDisplay()
    {
        farmDisplayUI.SetActive(false);
    }

    public void closeWoodCutterDisplay()
    {
        woodCutterDisplayUI.SetActive(false);
    }
}
