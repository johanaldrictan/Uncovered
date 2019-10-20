using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator anim;
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentent;
    // Start is called before the first frame update
    void Start()
    {
        sentent = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentent.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentent.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentent.Count == 0 )
        {
            EndDialogue();
            return;
        }

        string sentence = sentent.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("IsOpen", false);
    }


}
