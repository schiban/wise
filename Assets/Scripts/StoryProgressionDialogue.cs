using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StoryProgressionDialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radius;

    private DialogueControl dc;
    public bool isDialogueActive;
    bool onRadius;
    
    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onRadius && !isDialogueActive)
        {
            dc.Speech(speechTxt);
            isDialogueActive = true;
        }
    }

    public void SetDialogueActive(bool isActive)
    {
        isDialogueActive = isActive;
    }
    

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);

        if(hit != null)
        {
            onRadius = true;
        }
        else
        {
            onRadius = false;
            isDialogueActive = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void DisableCollider()
    {
        // if (dialogueIlse.enabled == true || dialogueWiseJo.enabled == true)
        // {
            dc.Speech(speechTxt);
            isDialogueActive = true;
        // }
        // else
        // {
        //     storyCollider.enabled = false;
        // }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            DisableCollider();
        }
    }
}
