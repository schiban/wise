using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryProgressionVillage : MonoBehaviour
{
    DialogueControlQuimZeion dialogueControlQuimZeion;

    private bool checkpoint1;
    private StoryProgressionControlVillage dc;
    public string[] speechTxt;
    public bool isDialogueActive;
    private Collider2D storyCollider;

public Sprite profile;
    public string actorName;

    public LayerMask playerLayer;

    
    void Awake()
    {
        dialogueControlQuimZeion = FindObjectOfType<DialogueControlQuimZeion>();
        dc = FindObjectOfType<StoryProgressionControlVillage>();
        storyCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        checkpoint1 = dialogueControlQuimZeion.checkpoint;

        if (checkpoint1)
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

