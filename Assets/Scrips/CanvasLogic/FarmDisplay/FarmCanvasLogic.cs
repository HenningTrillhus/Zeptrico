using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FarmCanvasLogic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject FarmPanel;
    public Button FarmButton;
    public Sprite NormalSprite;
    public Sprite HoverSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FarmButton.GetComponent<Image>().sprite = HoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FarmButton.GetComponent<Image>().sprite = NormalSprite;
    }

    
}
