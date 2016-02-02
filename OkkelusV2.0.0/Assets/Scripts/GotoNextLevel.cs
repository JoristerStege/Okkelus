using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GotoNextLevel : MonoBehaviour {

    private Text loadText;
    public Image panel;
    private Color fadeColor;
    private bool hit;
    private bool finished;
    private float timeToLoad = 0;
    private float loadTime = 1.5f;
    private enum FadeState { FadeOut, FadeIn, Stop };
    private FadeState fadeState;
    
    void Start()
    {
        panel.color = Color.black;
        fadeColor = Color.black;
        fadeState = FadeState.FadeIn;

    }
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
            fadeState = FadeState.FadeOut;
            if (Application.loadedLevelName != "Level3" && Application.loadedLevelName != "Level4")
            {
                loadText.enabled = true;
                loadText.horizontalOverflow = HorizontalWrapMode.Overflow;
                loadText.text = "Well Done, You completed this level. \nLoading next Level... \nPlease Wait";
            }
        }
    }
    private void FadeScreen()
    {
        switch (fadeState)
        {
            case FadeState.FadeOut:
                if (panel.color.a >= 1) 
                { 
                    fadeState = FadeState.Stop; 
                    return; 
                }
                fadeColor.a += 0.015f;
                panel.color = fadeColor;
                break;
            case FadeState.FadeIn:
                if (panel.color.a <= 0) 
                { 
                    fadeState = FadeState.Stop; 
                    return; 
                }
                fadeColor.a -= 0.002f;
                panel.color = fadeColor;
                break;
            case FadeState.Stop:
                break;
            default:
                break;
        }
    }
    void Update()
    {
        FadeScreen();
        if (hit && !finished)
        {
            timeToLoad += Time.deltaTime;
            if (timeToLoad > loadTime)
            {
                hit = false;

                Application.UnloadLevel("Level" + Application.loadedLevel);

               // PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                Application.LoadLevelAsync("Level" + (Application.loadedLevel + 1).ToString());
            }
        }
    }
}
