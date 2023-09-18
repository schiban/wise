using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    public int damageToGive;
    private PlayerHealth playerHealth;
    private float waitToHurt = 1f;
    private bool isTouching;
    private Animator animator;
    private EnemyMovement controller;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        animator = GetComponent<Animator>();
        controller = FindObjectOfType<EnemyMovement>();
    }

    void Update()
    {
        if (!playerHealth.isDead && !animator.GetBool("isDead"))
        {
            if (isTouching)
            {
                waitToHurt-= Time.deltaTime;
                if (waitToHurt <= 0)
                {
                    Cross();
                    waitToHurt = 2f;
                }
            }
        }
        else
        {
            controller.StopMoving();
        }
    }

    public void Cross()
    {
        animator.SetTrigger("Cross");
        playerHealth.HurtPlayer(damageToGive);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = true;
            animator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 1f;
        }
    }
}