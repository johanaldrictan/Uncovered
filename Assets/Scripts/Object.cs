using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Object : MonoBehaviour
{
    private DialogueManager logger;
    [TextArea(3,10)]
    public bool dialogActive;

    public Dialogue dialogue;
    bool player = false;
    bool dia = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        logger = DialogueManager.FindObjectOfType<DialogueManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && player)
        {
            player = false;
            dia = true;
            TriggerDialogue();
        }
        else
        if (Input.GetKeyDown(KeyCode.Space) && dia)
        {
            logger.DisplayNextSentence();
            if(logger.boxOn() == false)
            {
                dia = false;
                player = true;
            }
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
