using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloorScript : MonoBehaviour {

    public ActieTrigger trigger;
    private bool isLava;
    private float countDown = 5f;
    private Text loadText;
    private bool loading;
	// Use this for initialization
	void Start () {
        isLava = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (trigger.IsLava())
        {
            this.isLava = true;
        }
        if (countDown != 5 && !loading)
        {
            if (!isLava || loadText == null)
                return;

            loadText.text = "Well Done, You completed the game. \nLoading Credits in: " + countDown.ToString("F1") + " Seconds.";
             countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                loading = true;
                loadText.text = "Well Done, You completed the game. \nLoading Credits in: 0.0 Seconds.";
                Application.UnloadLevel("Level4");
                Application.LoadLevelAsync("Credits");
            }
        }
	}

    void OnCollisionEnter(Collision other)
    {

        if (this.isLava && other.gameObject.tag == "Player" && loadText == null)
        {
            Component[] temp;
            temp = other.gameObject.GetComponentsInChildren(typeof(Camera));
            temp = temp[0].GetComponentsInChildren(typeof(Canvas));
            temp = temp[2].GetComponentsInChildren(typeof(Text));
            loadText = (Text)temp[0];

            loadText.enabled = true;
            loadText.horizontalOverflow = HorizontalWrapMode.Overflow;
            loadText.text = "Well Done, You completed the game. \nLoading Credits in: "+ countDown.ToString("F1") + " Seconds.";

            countDown -= 0.000001f;
        }
    }
}
