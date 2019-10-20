using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KeyObject2 : MonoBehaviour
{
   private DialogueManager logger;
   private ItemManager iMan;
    [TextArea(3,10)]
    public bool dialogActive;

    public Dialogue dialogue;
    bool player = false;
    bool dia = false;
    public string key = "NONO";
    
    private bool MAINOBJECT = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        logger = DialogueManager.FindObjectOfType<DialogueManager>();
        iMan = ItemManager.FindObjectOfType<ItemManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && player){
            SceneManager.LoadScene(1);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
        player = true;
        iMan.found2ON();
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
