using UnityEngine;

public class HoverDisplay : MonoBehaviour
{
    [SerializeField] public GameObject hoverDisplay;
    [SerializeField] public GameObject hoverbox;

    public Transform npcTransform; 

    private Vector3 offset = new Vector3(0, 0.8f, 0);

    private bool isHovering = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        hoverDisplay.transform.position = npcTransform.position + offset;
        hoverDisplay.transform.rotation = Quaternion.identity;
    }

    void OnMouseOver()
    {
        // mouse is hovering this object right now
        isHovering = true;
        hoverDisplay.SetActive(isHovering);
        hoverbox.SetActive(isHovering);
    }

    void OnMouseExit()
    {
        // mouse just stopped hovering
        isHovering = false;
        hoverDisplay.SetActive(isHovering);
        hoverbox.SetActive(isHovering);
    }
}
