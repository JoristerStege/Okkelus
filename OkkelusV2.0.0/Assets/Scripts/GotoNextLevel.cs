using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GotoNextLevel : MonoBehaviour {

    [SerializeField]
    private CapsuleCollider Player;
    [SerializeField]
    private Text loadText;
    private bool hit;
    private float timeToLoad = 0;
	
    void OnTriggerEnter(Collider col)
    {
        if (col == Player && !hit)
        {
            hit = true;
            loadText.enabled = true;
            loadText.horizontalOverflow = HorizontalWrapMode.Overflow;
            loadText.text = "Well Done, You completed this level. \nLoading next Level... \nPlease Wait";

        }
        
    }
    void Update()
    {
        if (hit)
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
