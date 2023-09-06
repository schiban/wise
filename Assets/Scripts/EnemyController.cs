using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator animator;
    private Transform target;
    public Transform homePosition;

    [SerializeField] private float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    
    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome()
    {
        animator.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        animator.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePosition.position) == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }
}
