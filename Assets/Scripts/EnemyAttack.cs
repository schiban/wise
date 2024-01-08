using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;
    private EnemyMovement enemy;
    private PlayerHealth player;

    [Header("Abilities Damage")]
    public int damageToGive;
    private float waitToHurt = 1f;
    private bool isTouching;
    

    void Awake()
    {
        player = FindObjectOfType<PlayerHealth>();
        animator = GetComponent<Animator>();
        enemy = FindObjectOfType<EnemyMovement>();
    }

    void Update()
    {
        if (!player.isDead && !animator.GetBool("isDead"))
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
            enemy.StopMoving();
        }
    }
    
    public void Cross()
    {
        animator.SetTrigger("Cross");
        player.HurtPlayer(damageToGive);
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