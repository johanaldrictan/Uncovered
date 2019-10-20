using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private DialogueManager dialogueMan;
    private ItemManager itemMan;
    private Rigidbody2D rb;
    private Vector2 movement;

    public Grid grid;
    public Tilemap islandGround;

    public float walkSpeed = 10f;
    private Animator animator;
    private Vector3Int playerPosition2D;

    private List<string> grassTiles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerPosition2D = grid.WorldToCell(transform.position);
        grassTiles = new List<string>();
        grassTiles.Add("tf_jungle_tileset_31");
        grassTiles.Add("tf_jungle_tileset_33");
        grassTiles.Add("tf_jungle_tileset_13");
        grassTiles.Add("tf_jungle_tileset_14");
        grassTiles.Add("tf_jungle_tileset_15");
        grassTiles.Add("tf_jungle_tileset_32");
        grassTiles.Add("tf_jungle_tileset_47");
        grassTiles.Add("tf_jungle_tileset_48");
        grassTiles.Add("tf_jungle_tileset_49");

    }

    void Awake()
    {
        dialogueMan = DialogueManager.FindObjectOfType<DialogueManager>();
        itemMan = ItemManager.FindObjectOfType<ItemManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(dialogueMan.boxOn() != true)//STOP CHRACTER FROM MOVING IF DIALOGUE IS HAPPENING
        {
            /*
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = 0;
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                movement.y = Input.GetAxisRaw("Vertical");
                
                movement.x = 0;
            }
            else
            {
                movement.y = 0;
                movement.x = 0;
            }
            */
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }
        playerPosition2D = grid.WorldToCell(transform.position);
        if (islandGround.GetTile(playerPosition2D).name.Contains("beach") || islandGround.GetTile(playerPosition2D).name.Contains("sand") || islandGround.GetTile(playerPosition2D).name.Contains("Sand"))
        {
            AkSoundEngine.SetSwitch("Material", "Sand", gameObject);
        }
        else if (islandGround.GetTile(playerPosition2D).name.Contains("jungle") || islandGround.GetTile(playerPosition2D).name.Contains("dirt") || islandGround.GetTile(playerPosition2D).name.Contains("Dirt"))
        {
            Debug.Log(islandGround.GetTile(playerPosition2D).name);
            if(grassTiles.Contains(islandGround.GetTile(playerPosition2D).name))
                AkSoundEngine.SetSwitch("Material", "Grass", gameObject);
            else
                AkSoundEngine.SetSwitch("Material", "Dirt", gameObject);
            
        }
        else if (islandGround.GetTile(playerPosition2D).name.Contains("ashlands"))
        {
            AkSoundEngine.SetSwitch("Material", "Gravel", gameObject);
        }

    }
    private void FixedUpdate()
    {
        movement = movement.normalized;
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
        
    }
    public void PlayFootstep()
    {
        AkSoundEngine.PostEvent("Play_SFX_Walk", gameObject);
    }
}
