using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// "Movement" tem todas as variáveis associadas ao movimento do Player
    /// </summary>
    /// <param name="walkSpeed">Velocidade a caminhar</param>
    /// <param name="runSpeed">Velocidade a correr</param>
    /// <param name="isMoving">Booleano de verificação movimento de andamento</param>
    /// <param name="isRunning">Booleano de verificação movimento de corrida</param>
    /// <param name="input">Posição de um objeto num espaço 2D</param>
    /// <param name="animator">Controlador de parâmetros de animação do objeto</param>
    /// <param name="rb">Determinador da posição do objeto em tempo real</param>
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private float currentSpeed;
    private bool isRunning;
    private Vector2 input;
    private Animator animator;
    private Rigidbody2D rb;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /// <summary>
        /// Condição que executa sempre que existir movimento do Player
        /// </summary>

        input.x = Input.GetAxisRaw("Horizontal"); // Valor obtido no movimento usado pelas teclas A e D e pelas setas esquerda e direita
        input.y = Input.GetAxisRaw("Vertical"); // Valor obtido no movimento usado pelas teclas W e S e pelas setas cima e baixo

        /// <summary>
        /// Esta condição impede o movimento diagonal
        /// </summary>

        if (input.y != 0) input.x = 0;

        /// <summary>
        /// Condição que é executada se o valor registado é diferente de Vector2(0,0), isto é, a última posição registada do objeto
        /// </summary>

        if (input != Vector2.zero && animator.GetBool("isDead") == false)
        {
            // Se o booleano "isRunning" for verdadeiro, então é atribuído ao "speed" o valor da velocidade atribuída à variável "runSpeed"
            // Caso "isRunning" seja falso, então o valor atribuído ao "speed" é o valor da velocidade atribuído à variável "walkSpeed"
            currentSpeed = isRunning ? runSpeed : walkSpeed;

            // Mudança da posição do objeto, onde a posição atual e a velocidade são somadas ao produto entre o intervalo de tempo e o valor gerado pelo movimento
            rb.MovePosition(rb.position + currentSpeed * Time.fixedDeltaTime * input);

            animator.SetBool("isMoving", true);
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            animator.SetFloat("speed", input.sqrMagnitude);
        } 
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRunning", false);
        }

        /// <summary>
        /// Verificação se existe movimento e se o Left Shift foi pressionado
        /// </summary>
        if (Input.GetKey(KeyCode.LeftShift) && input != Vector2.zero)
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