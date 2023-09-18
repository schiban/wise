using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool isDead;
    private Animator animator;
    private RespawnPoint respawn;

    void Awake()
    {
        animator = GetComponent<Animator>();
        respawn = FindObjectOfType<RespawnPoint>();
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
            isDead = true;
            respawn.RespawnScene();
        }
    }
}
