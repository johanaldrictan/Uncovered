using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cursor : MonoBehaviour
{

    public Tilemap Layer1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            Move(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            Move(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Move(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            Move(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Dig();
        }

    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }

    public void Dig()
    {
        //Vector3 currentcell = 
    }
}
