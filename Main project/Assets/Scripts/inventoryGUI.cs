using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventoryGUI : MonoBehaviour {

	// Use this for initialization
    public Canvas canvas;
    public Button x;
	void Start () 
    {
        //GUI.Button(new Rect(0, 0, 10, 10), "hi");
        x = CreateButton(x, canvas, new Vector2(0, 0), new Vector2(10, 10));
        
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        //GUI.Button(new Rect(0, 0, 10, 10), "hi");
        
	}
    public static Button CreateButton(Button buttonPrefab, Canvas canvas, Vector2 cornerTopRight, Vector2 cornerBottomLeft)
    {
        var button = Object.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as Button;
        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.SetParent(canvas.transform);
        rectTransform.anchorMax = cornerTopRight;
        rectTransform.anchorMin = cornerBottomLeft;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        return button;
    }
}
