using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 input;

    [Header("Player Movement Speed")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float currentSpeed;
    private bool isRunning;
    private bool isMoving; // Variable to check if there is any movement input


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Esta condição impede o movimento diagonal
        if (input.x != 0)
            input.y = 0;

        isMoving = input != Vector2.zero;

        if (isMoving && animator.GetBool("isDead") == false)
        {
            // Se isRunning for verdadeiro, então currentSpeed = runSpeed
            // Caso contrário, currentSpeed = walkSpeed
            currentSpeed = isRunning ? runSpeed : walkSpeed;

            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            animator.SetFloat("speed", input.sqrMagnitude);

            // Mudança da posição do objeto, onde a posição atual e a velocidade são somadas ao produto entre o intervalo de tempo e o valor gerado pelo movimento
            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * input);
        } 
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRunning", false);
        }

        // Verificação se existe movimento e se o Left Shift está a ser pressionado
        if (Input.GetKey(KeyCode.LeftShift) && isMoving)
        {
            isRunning = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }
    }
}