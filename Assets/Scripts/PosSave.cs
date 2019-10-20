using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PosSave : MonoBehaviour
{
    Vector3 vectoerP;
    public PosSave myPos;
    public static Player thePlaya;
    void Awake()
    {
        myPos = PosSave.FindObjectOfType<PosSave>();
        thePlaya = Player.FindObjectOfType<Player>();
    }
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            vectoerP = thePlaya.transform.position;
        }
    }

    public Vector3 getPos()
    {
        return vectoerP;
    }
    
}
