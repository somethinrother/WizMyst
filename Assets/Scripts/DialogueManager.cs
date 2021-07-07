using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public bool dialogueIsActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueIsActive && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueBox.SetActive(false);
            dialogueIsActive = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogueIsActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }
}
