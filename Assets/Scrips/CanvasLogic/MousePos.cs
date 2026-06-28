using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MousePos : MonoBehaviour
{
    public TextMeshProUGUI mousePosText;
    public GameObject mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePos.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosText.text = "X: " + worldPos.x.ToString("F2") + " Y: " + worldPos.y.ToString("F2");
    }
}
