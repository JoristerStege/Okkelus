using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FridgeLock : MonoBehaviour {

	// Use this for initialization
    public Canvas canvas;
    public GameObject[] topSelect = new GameObject[3];
    public Text[] inputfield = new Text[3];
    public GameObject[] bottumSelect = new GameObject[3];
    public Collider fridgeCollider;
    public GameObject fridge;
    public int colliderRadius;
    public LayerMask layer;
    public Camera camera;
    public int code = 573;

    private int selected = 0;
    bool vertPressed, HorizontalPressed;
	void Start () {
       // canvas.enabled = false;
        for (int i = 0; i < 3; i++)
        {
            topSelect[i].SetActive(false);
            bottumSelect[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (canvas.enabled)
        {
            // nummer seleteren 
            #region numberSelect
            if (Input.GetAxis("DpadVertical") != 0 && !vertPressed)
            {
                vertPressed = true;
                int num = int.Parse(inputfield[selected].text);

                if (Input.GetAxis("DpadVertical") < 0)
                    num = num == 0 ? 9 : --num;

                if (Input.GetAxis("DpadVertical") > 0)
                    num = num == 9 ? 0 : ++num;

                inputfield[selected].text = num.ToString();
            }
            else if (Input.GetAxis("DpadVertical") == 0 && vertPressed)
                vertPressed = false;
            #endregion
            // inputfield veranderen
            #region inputfield
            if (Input.GetAxis("DpadHorizontal") != 0 && !HorizontalPressed)
            {
                HorizontalPressed = true;
                topSelect[selected].SetActive(false);
                bottumSelect[selected].SetActive(false);

                if (Input.GetAxis("DpadHorizontal") < 0)
                    selected--;

                if (Input.GetAxis("DpadHorizontal") > 0)
                    selected++;

                if (selected < 0)
                    selected = 2;
                if (selected > 2)
                    selected = 0;

                topSelect[selected].SetActive(true);
                bottumSelect[selected].SetActive(true);
            }
            else if (Input.GetAxis("DpadHorizontal") == 0 && HorizontalPressed)
            {
                HorizontalPressed = false;
            }
            #endregion
        }

        // Y button
        if (Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            string num = "";
            for (int i = 0; i < 3; i++)
            {
                num += inputfield[i].text;
            }
            Debug.Log(num);
            if (code == int.Parse(num))
            {
                fridgeCollider.isTrigger = true;
                canvas.enabled = false;
            }
        }
        // B button
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            canvas.enabled = false;

            for (int i = 0; i < 3; i++)
                inputfield[i].text = "0";
        }
        // X button
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            #region
            Collider[] item = Physics.OverlapSphere(transform.position, colliderRadius, layer);
            for (int i = 0; i < item.Length; i++)
            {
                Vector3 direction = item[i].transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle < camera.fieldOfView * 0.7f)
                {
                    Ray ray = new Ray(transform.position, direction);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, direction.magnitude + 10))
                        canvas.enabled = true;
                }
            }
            #endregion
        }
        if (canvas.enabled)
        {
            Vector3 direction = fridge.transform.position - transform.position;
            if (direction.magnitude > colliderRadius + 3)
            {
                canvas.enabled = false;
                for (int i = 0; i < 3; i++)
                    inputfield[i].text = "0";
            }
        }
    }
}
