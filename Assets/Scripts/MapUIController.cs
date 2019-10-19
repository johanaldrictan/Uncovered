using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIController : MonoBehaviour
{
    private MapUIController instance;

    Ray ray;
    RaycastHit2D hit;
    HoverState hover_state;
    Vector3Int lastTileLoc;

    public Vector3Int tilePointer;

    //public TileBase tileSelector;

    public bool arrowKeysToggle;

    private void Awake()
    {
        //there should only be one mapuicontroller
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if mouse has moved in any way
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            arrowKeysToggle = false;

        if (!arrowKeysToggle)
            MouseOverTile();
        HandleArrowKeyInput();

        HandleInputClick();
    }
    public void HandleArrowKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrowKeysToggle = true;
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(-1, 0, 0);
            //TODO: check if in bounds

            hover_state = HoverState.HOVER;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowKeysToggle = true;
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(1, 0, 0);
            //TODO: check if in bounds

            hover_state = HoverState.HOVER;

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrowKeysToggle = true;
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(0, 1, 0);
            //TODO: check if in bounds

            hover_state = HoverState.HOVER;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrowKeysToggle = true;
            Vector3Int tryMoveTilePointer = tilePointer + new Vector3Int(0, -1, 0);
            //TODO: check if in bounds

            hover_state = HoverState.HOVER;

        }
        //if (lastTileLoc != null)
        //    tileSelecting.SetTile(lastTileLoc, null);
        lastTileLoc = tilePointer;
        //tileSelecting.SetTile(tilePointer, tileSelector);

    }
    public void HandleInputClick()
    {
        

    }

    public void MouseOverTile()
    {
        //Start Tile highlighting code
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 100f);
        if (hit)
        {
            hover_state = HoverState.HOVER;
        }
        else
        {
            hover_state = HoverState.NONE;
        }

        if (hover_state == HoverState.HOVER)
        {
            //Mouse is hovering
            //Debug.Log(mapController.GridToMap(mapController.grid.WorldToCell(hit.point)));
            //Debug.Log(MapController.instance.grid.WorldToCell(hit.point));
            //if (lastTileLoc != null)
            //    tileSelecting.SetTile(lastTileLoc, null);
            lastTileLoc = MapController.instance.grid.WorldToCell(hit.point);
            tilePointer = MapController.instance.grid.WorldToCell(hit.point);
        }
        //else
        //{
        //    tileSelecting.SetTile(lastTileLoc, null);
        //}
        //End Tile highlighting code
    }
}
public enum HoverState
{
    NONE,
    HOVER
}