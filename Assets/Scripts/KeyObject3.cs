using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KeyObject3 : MonoBehaviour
{
   private DialogueManager logger;
   private ItemManager iMan;
    [TextArea(3,10)]
    public bool dialogActive;

    public Dialogue dialogue;
    bool player = false;
    bool dia = false;
    public string key = "NONO";
    public PosSave positioner;
    private bool MAINOBJECT = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {
        logger = DialogueManager.FindObjectOfType<DialogueManager>();
        iMan = ItemManager.FindObjectOfType<ItemManager>();
        positioner = PosSave.FindObjectOfType<PosSave>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && player){
            DontDestroyOnLoad(positioner);
            SceneManager.LoadScene(4);
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
