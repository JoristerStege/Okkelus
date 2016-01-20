using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        InvokeRepeating("ChangeColorLight", 0, 2);
        }

    void ChangeColorLight()
    {

        int index = Random.Range(1, 9);

        switch (index)
        {
            case 1:
                {
                    this.GetComponent<Light>().color = Color.black;
                    break;
                }
            case 2:
                {
                    this.GetComponent<Light>().color = Color.blue;
                    break;
                }
            case 3:
                {
                    this.GetComponent<Light>().color = Color.cyan;
                    break;
                }
            case 4:
                {
                    this.GetComponent<Light>().color = Color.gray;
                    break;
                }
            case 5:
                {
                    this.GetComponent<Light>().color = Color.green;
                    break;
                }
            case 6:
                {
                    this.GetComponent<Light>().color = Color.magenta;
                    break;
                }
            case 7:
                {
                    this.GetComponent<Light>().color = Color.red;
                    break;
                }
            case 8:
                {
                    this.GetComponent<Light>().color = Color.white;
                    break;
                }
            case 9:
                {
                    this.GetComponent<Light>().color = Color.yellow;
                    break;
                }
        }
	}
}
