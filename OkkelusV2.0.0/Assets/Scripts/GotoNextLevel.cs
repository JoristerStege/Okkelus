using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GotoNextLevel : MonoBehaviour {

    [SerializeField]
    private CapsuleCollider PlayerCollider;
    [SerializeField]
    private Text loadText;
    [SerializeField][Tooltip("Only needed in Lvl 3")]
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController Player;
    private bool hit;
    private bool loading;
    private float timeToLoad = 0;
	
    void OnTriggerEnter(Collider col)
    {

        if (col == PlayerCollider && !hit)
        {
            hit = true;
            if (Application.loadedLevelName == "Level3")
            {
                DontDestroyOnLoad(Player);
                timeToLoad = 2;
            }
            else
            {
                loadText.enabled = true;
                loadText.horizontalOverflow = HorizontalWrapMode.Overflow;
                loadText.text = "Well Done, You completed this level. \nLoading next Level... \nPlease Wait";
            }
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
