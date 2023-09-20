using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    public float health;
    [SerializeField] private float maxHealth;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (health < maxHealth && health > 0)
        {
            maxHealth = health;
            animator.SetTrigger("Hit");
        }

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            StartCoroutine(Death());
        }
    }

    // O inimigo desaparece do mapa passado 1 segundo de ter morrido
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);

        // gameObject.SetActive(false);
    }
}
