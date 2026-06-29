using UnityEngine;

public class BuildingSpriteDataBase : MonoBehaviour
{
    public static BuildingSpriteDataBase Instance;

    public Sprite farmSprites;
    public Sprite WoodCutterSprite;

    

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetSprite(int id)
    {
        if (id == 0)
        {
            return farmSprites;
        }
        else if (id == 1)
        {
            return WoodCutterSprite;
        }
        else
        {
            return null;
        }
    }
}
