using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 6f;
    private bool isMoving;
    private bool isRunning;
    private Vector2 input;
    public Animator animator;
    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lock input while moving
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            // input.Normalize();

            // Avoid diagonal animation
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                float speed = isRunning ? runSpeed : walkSpeed;
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * input);

                animator.SetBool("isMoving", true);
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                animator.SetFloat("speed", input.sqrMagnitude);
            } 
            else
            {
                animator.SetBool("isMoving", false);
                animator.SetBool("isRunning", false);
            }
        }

        // Toggle run mode
        if (Input.GetKey(KeyCode.LeftShift) && input != Vector2.zero)
        {
            isRunning = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && input != Vector2.zero)
        {
            PlayAttackAnimation("jab");
        }
        // else if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     PlayAttackAnimation("Cross");
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     PlayAttackAnimation("Blaze");
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     PlayAttackAnimation("MegaCross");
        // }
    }

    private void PlayAttackAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
        Debug.Log(animationName);
    }
}