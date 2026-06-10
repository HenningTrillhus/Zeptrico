using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private PlacingBoxFallow placingBoxFallow;

    private int placingBuildingid = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        placingBoxFallow = GetComponent<PlacingBoxFallow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (placingBoxFallow.isPlacing)
        {
            Sprite sprite = BuildingSpriteDataBase.Instance.GetSprite(placingBuildingid);
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
