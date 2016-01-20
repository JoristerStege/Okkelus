using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GotoNextLevel : MonoBehaviour {

    private Text loadText;
    private bool hit;
    private bool loading;
    private float timeToLoad = 0;
	
    void OnTriggerEnter(Collider col)
    {
        if (col.isTrigger)
            return;
        if (col.gameObject.name == "RigidBodyFPSController" && !hit)
        {
            Component[] temp;
            temp = col.gameObject.GetComponentsInChildren(typeof(Camera));
            temp = temp[0].GetComponentsInChildren(typeof(Canvas));
            temp = temp[2].GetComponentsInChildren(typeof(Text));
            loadText = (Text)temp[0];
            hit = true;
           
            if (Application.loadedLevelName != "Level3")
            {
                loadText.enabled = true;
                loadText.horizontalOverflow = HorizontalWrapMode.Overflow;
                loadText.text = "Well Done, You completed this level. \nLoading next Level... \nPlease Wait";
            }
            if (Application.loadedLevelName == "Level3")
            {
                DontDestroyOnLoad(col.gameObject.gameObject);
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                Application.LoadLevelAsync("Level" + PlayerPrefs.GetInt("Level"));
                loading = true;
            }
        }
    }

    void Update()
    {
        if (hit && !loading)
        {
            timeToLoad += Time.deltaTime;
            if (timeToLoad > 1.5f)
            {
                hit = false;
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                Application.LoadLevelAsync("Level" + PlayerPrefs.GetInt("Level"));
            }
        }
    }
}
