using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    public CircleCollider2D circleCollider;
    public Vector2 colliderOffset = Vector2.zero; // Adjust this offset as needed
    private Vector2 facingDirection;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        // Check character's facing direction
        facingDirection.x = Input.GetAxisRaw("Horizontal");
        facingDirection.y = Input.GetAxisRaw("Vertical");

        if (facingDirection != Vector2.zero)
        {
            // facingDirection.Normalize();
            if (facingDirection.x != 0) facingDirection.y = 0;

            // Update the collider's offset based on facing direction
            circleCollider.offset = colliderOffset + facingDirection;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        playerHealth.Damage(damage);
    }
}