using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcavationButton : MonoBehaviour
{
    
    public Sprite RedOff;
    public Sprite RedOn;
    public Sprite GreenOff;
    public Sprite GreenOn;

    public Button Red;
    public Button Green;

    private bool RedStatus;
    private bool GreenStatus;

    // Start is called before the first frame update
    void Start()
    {
        RedStatus = false;
        GreenStatus = true;
        Red.image.sprite = RedOff;
        Green.image.sprite = GreenOn;
    }

    public void PressRed()
    {
        if (!RedStatus) {
            Red.image.sprite = RedOn;
            Green.image.sprite = GreenOff;
            RedStatus = true;
            GreenStatus = false;
        }
    }

    public void PressGreen()
    {
        if (!GreenStatus) {
            Red.image.sprite = RedOff;
            Green.image.sprite = GreenOn;
            RedStatus = false;
            GreenStatus = true;
        }
    }

    public bool BigDigOn() {
        return RedStatus;
    }
}
