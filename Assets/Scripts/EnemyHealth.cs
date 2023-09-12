using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("Hit");
            
        }

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }
}
