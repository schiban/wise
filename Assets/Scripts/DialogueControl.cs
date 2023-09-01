using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject dialogueObject;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Definições")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    private bool isTyping = false;

    public void Speech(string[] txt)
    {
        dialogueObject.SetActive(true);
        sentences = txt;
        StartCoroutine(TypeSentence());
    }

    private void Update()
    {
        // Listen for keyboard input to advance dialogue
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
        {
            NextSentence();
        }
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    public void NextSentence()
    {
        if (isTyping) return; // Check if typing is in progress 

        if(speechText.text.Length == sentences[index].Length)
        {
            // ainda tem textos
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            // não tem mais textos
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObject.SetActive(false);
                // Access the Dialogue script and set the isDialogueActive value
                Dialogue dialogueScript = FindObjectOfType<Dialogue>();
                if (dialogueScript != null)
                    dialogueScript.SetDialogueActive(false); // Change the value as needed

                // GetComponent<Dialogue>().isDialogueActive = false;
            }
        }
    }
}
