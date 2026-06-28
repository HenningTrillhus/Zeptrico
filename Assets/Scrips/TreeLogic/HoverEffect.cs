using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverEffect : MonoBehaviour

{
    private int treeType;
    private bool isHovering = false;

    [Header("Sprites")]
    public Sprite PineTree;
    public Sprite PineTreeHover;
    public Sprite OakTree;
    public Sprite OakTreeHover;
    public Sprite BirchTree;
    public Sprite BirchTreeHover;
    public Sprite AshTree;
    public Sprite AshTreeHover;
    
    public GameObject hoverbox;
    public GameObject hoverDisplay;

    public TextMeshPro TreeTextName;

    private SpriteRenderer sr;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeType = Random.Range(1, 5); // Randomly assign tree type (1, 2, 3, or 4)
        sr = GetComponent<SpriteRenderer>();
        hoverbox.SetActive(false);
        hoverDisplay.SetActive(false);

        if (treeType == 1)
        {
            sr.sprite = PineTree;
            TreeTextName.text = "Pine Tree";
        }
        else if (treeType == 2)
        {
            sr.sprite = OakTree;
            TreeTextName.text = "Oak Tree";
        }
        else if (treeType == 3)
        {
            sr.sprite = BirchTree;
            TreeTextName.text = "Birch Tree";
        }
        else if (treeType == 4)
        {
            sr.sprite = AshTree;
            TreeTextName.text = "Ash Tree";
        }
    }

    void OnMouseOver()
    {
        // mouse is hovering this object right now
        isHovering = true;
        if (treeType == 1)
        {
            sr.sprite = PineTreeHover;
        }
        else if (treeType == 2)
        {
            sr.sprite = OakTreeHover;
        }
        else if (treeType == 3)
        {
            sr.sprite = BirchTreeHover;
        }
        else if (treeType == 4)
        {
            sr.sprite = AshTreeHover;
        }
        hoverbox.SetActive(isHovering);
        hoverDisplay.SetActive(isHovering);
    }

    void OnMouseExit()
    {
        // mouse just stopped hovering
        isHovering = false;
        if (treeType == 1)
        {
            sr.sprite = PineTree;
        }
        else if (treeType == 2)
        {
            sr.sprite = OakTree;
        }
        else if (treeType == 3)
        {
            sr.sprite = BirchTree;
        }
        else if (treeType == 4)
        {
            sr.sprite = AshTree;
        }
        hoverbox.SetActive(isHovering);
        hoverDisplay.SetActive(isHovering);
    }
}
