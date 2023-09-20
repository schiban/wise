using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;
    private Transform target;
    public Transform homePosition;

    [Header("Enemy Movement Speed")]
    [SerializeField] private float speed;
    [SerializeField] private bool canMove;

    [Header("Enemy Targetting Range")]
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    private float distanceToTarget;

    void Awake()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Start()
    {
        canMove = true;
    }

    private void Update()
    {
        /// <summary>
        /// Verifica se o inimigo se pode mover
        /// </summary>
        /// <param name="distanceToTarget">Distância entre a posição do protagonista e o inimigo</param>
        /// <returns>Retorna métodos de movimento dependendo do valor da distância e o raio de contacto</returns>
        if (canMove)
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (distanceToTarget >= minRange && distanceToTarget <= maxRange)
            {
                FollowPlayer();
            }
            else if (distanceToTarget >= maxRange)
            {
                GoHome();
            }
            /*
            if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
            {
                FollowPlayer();
            }
            else if (Vector3.Distance(target.position, transform.position) >= maxRange)
            {
                GoHome();
            }
            */
        }
    }

    public void FollowPlayer() // Persegue o protagonista
    {
        canMove = true;

        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome() // Regressa ao ponto de partida
    {
        canMove = true;

        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        animator.SetFloat("moveY", (homePosition.position.y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePosition.position) == 0)
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void StopMoving() // Para de se mover
    {
        canMove = false;
        animator.SetBool("isMoving", false);
    }
}