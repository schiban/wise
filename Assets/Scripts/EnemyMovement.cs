using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Transform target;
    public Transform homePosition;

    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    private bool canMove = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (canMove) // Check if the character can move
        {
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            {
                FollowPlayer();
            }
            else if (Vector3.Distance(target.position, transform.position) >= maxRange)
            {
                GoHome();
            }
        }
    }

    public void FollowPlayer()
    {
        canMove = true;
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));
        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        canMove = true;
        animator.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        animator.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePosition.position) == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void StopMoving()
    {
        canMove = false; // Set the boolean to false to stop movement
        animator.SetBool("isMoving", false);
    }
}