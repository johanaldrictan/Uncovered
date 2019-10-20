using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool item1Found;
    private bool item2Found;
    public Animator found1;
    public Animator found2;
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
            found1.SetBool("Found1", true);
        }
        if(item2Found == true)
        {
            found2.SetBool("Found2", true);
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
