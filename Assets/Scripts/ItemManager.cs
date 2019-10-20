using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool item1Found;
    private bool item2Found;
    public GameObject img1;
    public GameObject img2;
    // Start is called before the first frame update
    void Start()
    {
        item1Found = false;
        item2Found = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(item1Found == true)
        {
            Destroy(img1);
        }
        if(item2Found == true)
        {
            Destroy(img2);
        }
    }

    public void found1ON()
    {
        item1Found = true;
    }

    public void found2ON()
    {
        item2Found = true;
    }
}
