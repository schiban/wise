using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProgression : MonoBehaviour
{
    DialogueControlWiseJo dialogueControlWiseJo;
    DialogueControlIlde dialogueControlIlde;

    private bool checkpoint1;
    private bool checkpoint2;
    private StoryProgressionControl dc;
    public string[] speechTxt;
    public bool isDialogueActive;
    private Collider2D storyCollider;

public Sprite profile;
    public string actorName;

    public LayerMask playerLayer;

    
    void Awake()
    {
        dialogueControlWiseJo = FindObjectOfType<DialogueControlWiseJo>();
        dialogueControlIlde = FindObjectOfType<DialogueControlIlde>();
        dc = FindObjectOfType<StoryProgressionControl>();
        storyCollider = GetComponent<Collider2D>();
    }


    void Update()
    {
        checkpoint1 = dialogueControlIlde.checkpoint;
        checkpoint2 = dialogueControlWiseJo.checkpoint;

        if (checkpoint1 && checkpoint2)
        {
            storyCollider.enabled = false;
        }
        else
        {
            storyCollider.enabled = true;
        }

    }


    public void SetDialogueActive(bool isActive)
    {
        isDialogueActive = isActive;
    }

    private void DisableCollider()
    {
        dc.Speech(speechTxt);
        isDialogueActive = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            DisableCollider();
        }
    }
}

