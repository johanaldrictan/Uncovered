using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject img1;
    public GameObject img2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Global.item1found == true)
        {
            Destroy(img1);
        }
        if(Global.item2found == true)
        {
            Destroy(img2);
        }
    }

    public void found1ON()
    {
        Global.item1found = true;
    }

    public void found2ON()
    {
        Global.item2found = true;
    }
}
