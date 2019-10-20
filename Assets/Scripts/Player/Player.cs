using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;
    bool otherObject = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

        public Animator animator;
    // Update is called once per frame
    void Update()
    {
        float speed = 10f;
        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKeyDown(KeyCode.Space) && otherObject)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                //string diag = "This is a " + T;
                dialogText.text = "diag";
            }
        }else
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
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY",moveY);
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        otherObject = true;
        Debug.Log(other.GetType());
        Debug.Log("WORKS");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        otherObject = false;
        Debug.Log("YEET");
        dialogBox.SetActive(false);
    }
}
