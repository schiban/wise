using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 vector;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        vector = Vector2.zero;
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y= Input.GetAxisRaw("Vertical");
        vector.Normalize();

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        if (vector != Vector2.zero)
        {
            UpdateMovement();

            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", vector.x);
            animator.SetFloat("Vertical", vector.y);
            animator.SetFloat("Speed", vector.sqrMagnitude);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void UpdateMovement() {
        // Movement
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * vector);
    }
}
