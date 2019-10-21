using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressOne : MonoBehaviour
{
    public GameObject image;

    public GameObject hint2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Global.hint1 == false)
            {
                image.SetActive(true);
                Global.hint1 = true;
            }
            else{
                image.SetActive(false);
                Global.hint1 = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(Global.hint2 == false)
            {
                hint2.SetActive(true);
                Global.hint2 = true;
            }
            else{
                hint2.SetActive(false);
                Global.hint2 = false;
            }
        }
    }
}
