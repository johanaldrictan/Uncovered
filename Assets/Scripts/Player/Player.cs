using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private DialogueManager dialogueMan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        dialogueMan = DialogueManager.FindObjectOfType<DialogueManager>();
    }
        public Animator animator;
    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        float moveX = 0f;
        float moveY = 0f;
        if(dialogueMan.boxOn() == true)//STOP CHRACTER FROM MOVING IF DIALOGUE IS HAPPENING
        {

        }
        else
        {
        if(Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
        }
        else
        if(Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }
        }
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY",moveY);
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    
}
