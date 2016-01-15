using UnityEngine;
using System.Collections;

public class GotoNextLevel : MonoBehaviour {

    [SerializeField]
    private CapsuleCollider Player;
    private bool hit;
    private AsyncOperation loadnew;
	
    void OnCollisionEnter(Collision col)
    {
        if (col.collider == Player && !hit)
        {
            hit = true;
           // Application.LoadLevelAsync
            //Application.UnloadLevel("Level" + PlayerPrefs.GetInt("Level"));
            PlayerPrefs.SetInt("Level", 2);//PlayerPrefs.GetInt("Level") + 1);
            loadnew = Application.LoadLevelAsync("Level" + PlayerPrefs.GetInt("Level"));
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (hit)
        {
            Debug.Log(loadnew.progress);
            
        }
    }
}
