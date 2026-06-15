using UnityEngine;

public class CanvasLogic : MonoBehaviour
{
    public GameObject BuildPanel;

    private bool buildingPanelVisible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildPanel.SetActive(false); 
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
}
