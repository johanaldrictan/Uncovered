using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Object : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;

    public Dialogue dialogue;
    bool player = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && player)
        {
            /*
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                //string diag = "This is a " + T;
                TriggerDialogue();
            }*/
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
        player = true;
        Debug.Log(other.GetType());
        Debug.Log("WORKS");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = false;
            Debug.Log("YEET");
            //dialogBox.SetActive(false);
        }
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
