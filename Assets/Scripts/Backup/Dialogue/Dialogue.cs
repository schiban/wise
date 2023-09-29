using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    public float radius;

    private DialogueControl dc;
    public bool isDialogueActive = false;
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
        if(Input.GetKeyDown(KeyCode.Space) && onRadius && !dc.isDialogueActive)
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
}
