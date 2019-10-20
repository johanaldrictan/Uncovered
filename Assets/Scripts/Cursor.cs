using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cursor : MonoBehaviour
{

    public Tilemap Layer1;
    public Tilemap Layer2;
    public Tilemap Layer3;
    public Tilemap BottomLayer;

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
        if (Layer3.GetTile(Layer3.WorldToCell(transform.position)) != null) {
            Vector3Int currentcell = Layer3.WorldToCell(transform.position);
            Layer3.SetTile(currentcell, null);
        }
        else if (Layer2.GetTile(Layer2.WorldToCell(transform.position)) != null) {
            Vector3Int currentcell = Layer2.WorldToCell(transform.position);
            Layer2.SetTile(currentcell, null);
        }
        else if (Layer1.GetTile(Layer1.WorldToCell(transform.position)) != null) {
            Vector3Int currentcell = Layer1.WorldToCell(transform.position);
            Layer1.SetTile(currentcell, null);
        }
        else {
            Debug.Log("YEEEEEEEEEEEEEE");
        }
    }
}
