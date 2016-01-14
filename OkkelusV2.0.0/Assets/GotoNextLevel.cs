using UnityEngine;
using System.Collections;

public class GotoNextLevel : MonoBehaviour {

    [SerializeField]
    private CapsuleCollider Player;
    private bool hit;
	
    void OnCollisionEnter(Collision col)
    {
        if (col.collider == Player && !hit)
        {
            hit = true;
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            Application.LoadLevel("Level" + PlayerPrefs.GetInt("Level"));
        }
    }
}
