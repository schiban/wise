using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth;
    private Animator animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        health = maxHealth;
    }

    public void HurtPlayer(int damageToGive)
    {
        animator.SetTrigger("Hit");
        health -= damageToGive;
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            Debug.Log("Player died");
        }
    }
}
