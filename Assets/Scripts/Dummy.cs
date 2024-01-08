using UnityEngine;

public class Dummy : MonoBehaviour
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
        if (health < maxHealth)
        {
            maxHealth = health;
            animator.SetTrigger("Hit");
        }
    }
}
