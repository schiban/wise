using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private float maxHealth;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
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

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);

        // gameObject.SetActive(false);
    }
}
