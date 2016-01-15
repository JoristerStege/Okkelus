using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Canvas canvas;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController script;

    private int index;
    private Text[] texts;
    private float wait;

    // Use this for initialization
    void Start()
    {
        texts = new Text[] { text1, text2, text3 };
        index = 0;
        canvas.enabled = false;
        texts[index].text += " <";
        script = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.JoystickButton7))
        {
            canvas.enabled = true;
            script.enabled = false;
        }

        wait += Time.deltaTime;

        if (wait >= 0.15)
        {
            if (Input.GetAxis("DpadVertical") > 0 || Input.GetKey(KeyCode.UpArrow))
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

            if (Input.GetAxis("DpadVertical") < 0 || Input.GetKey(KeyCode.DownArrow))
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


            if (Input.GetButton("Fire1"))
            {
                switch (index)
                {
                    case 0:
                        canvas.enabled = false;
                        script.enabled = true;
                        break;
                    case 1:
                        Application.LoadLevel(Application.loadedLevelName);
                        break;
                    case 2:
                        Application.Quit();
                        //Application.LoadLevel("Startmenu");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
