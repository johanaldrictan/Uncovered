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

    public int hits;

    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(hits >= 50) {
            Debug.Log("loselseosles");
        }
        if(Input.GetKeyDown(KeyCode.W) && transform.position.y < 4) {
            Move(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -6) {
            Move(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.y > -4) {
            Move(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 6) {
            Move(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Dig(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            BigDig(transform.position);
        }


    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }

    public void Dig(Vector2 position)
    {
        hits++;
        if (Layer3.GetTile(Layer3.WorldToCell(position)) != null) {
            Vector3Int currentcell = Layer3.WorldToCell(position);
            Layer3.SetTile(currentcell, null);
        }
        else if (Layer2.GetTile(Layer2.WorldToCell(position)) != null) {
            Vector3Int currentcell = Layer2.WorldToCell(position);
            Layer2.SetTile(currentcell, null);
        }
        else if (Layer1.GetTile(Layer1.WorldToCell(position)) != null) {
            Vector3Int currentcell = Layer1.WorldToCell(position);
            Layer1.SetTile(currentcell, null);
        }
    }

    public void BigDig(Vector2 position)
    {
        bool canUp = position.y < 4;
        bool canDown = position.y > -4;
        bool canLeft = position.x > -6;
        bool canRight = position.x < 6;

        Dig(position);
        if (canUp) {
            Dig(position + Vector2.up);
        }
        if (canDown) {
            Dig(position + Vector2.down);
        }
        if (canLeft) {
            Dig(position + Vector2.left);
        }
        if (canRight) {
            Dig(position + Vector2.right);
        }
        if (canUp && canRight) {
            Dig(position + Vector2.right + Vector2.up);
        }
        if (canUp && canLeft) {
            Dig(position + Vector2.left + Vector2.up);
        }
        if (canDown && canRight) {
            Dig(position + Vector2.right + Vector2.down);
        }
        if (canDown && canLeft) {
            Dig(position + Vector2.left + Vector2.down);
        }
    }
}
