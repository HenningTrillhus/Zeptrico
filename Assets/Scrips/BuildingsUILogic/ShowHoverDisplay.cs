using UnityEngine;

public class ShowHoverDisplay : MonoBehaviour
{
    [SerializeField] public GameObject hoverbox;
    private bool isHovering = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        // mouse is hovering this object right now
        isHovering = true;
        hoverbox.SetActive(isHovering);
    }

    void OnMouseExit()
    {
        // mouse just stopped hovering
        isHovering = false;
        hoverbox.SetActive(isHovering);
    }
}
