using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private DialogueManager dialogueMan;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float walkSpeed = 10f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Awake()
    {
        dialogueMan = DialogueManager.FindObjectOfType<DialogueManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(dialogueMan.boxOn() != true)//STOP CHRACTER FROM MOVING IF DIALOGUE IS HAPPENING
        {
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

            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
        }
    }
    private void FixedUpdate()
    {
        movement = movement.normalized;
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
    }


}
