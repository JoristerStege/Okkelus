using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public Text text1;
    public Text text2;
    public Text text3;

    private int index;
    private Text[] texts;
    private float wait;

	// Use this for initialization
	void Start () {
        texts = new Text[] {text1, text2, text3 };
        index = 0;
        texts[index].text += " <";
    }
	
	// Update is called once per frame
	void Update () {

        wait += Time.deltaTime;

        if (wait >= 0.15)
        {
            if (Input.GetAxis("DpadVertical") > 0)
            {
                texts[index].text = texts[index].text.Trim(" <".ToCharArray());
                if (index == 0)
                {
                    index = 2;
                }
                else
                {
                    index--;
                }

                texts[index].text += " <";
            }

            if (Input.GetAxis("DpadVertical") < 0)
            {
                texts[index].text = texts[index].text.Trim(" <".ToCharArray());
                if (index == 2)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }

                texts[index].text += " <";
            }
            wait = 0;
        }


        if (Input.GetButton("Fire1"))
        {
            switch (index)
            {
                case 0:
                    Application.LoadLevel("A03Release");
                    break;
                case 1:
                    Application.LoadLevel("Credits");
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }

    }
}

