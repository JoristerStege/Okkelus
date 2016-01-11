using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    public GameObject Player;
    public GameObject Plane;
    public Light[] Lights = new Light[2];

    private inventoryUtility inUt;

	// Use this for initialization
	void Start () {
        inUt = Player.GetComponent<inventoryUtility>();
        for (int i = 0; i < Lights.Length; i++)
            Lights[i].enabled = false;
        Plane.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (inUt.GetPoweredKey())
        {
            for (int i = 0; i < Lights.Length; i++)
                Lights[i].enabled = true;
            Plane.SetActive(true);
        }
	}
}
