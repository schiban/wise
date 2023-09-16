using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// "Movement" tem todas as variáveis associadas ao movimento do Player
    /// </summary>
    /// <param name="_walkSpeed">Velocidade a caminhar</param>
    /// <param name="_runSpeed">Velocidade a correr</param>
    /// <param name="isMoving">Booleano de verificação movimento de andamento</param>
    /// <param name="isRunning">Booleano de verificação movimento de corrida</param>
    /// <param name="input">Posição de um objeto num espaço 2D</param>
    /// <param name="_lastInput">Posição Vector2(0,0) para controlo de movimento diagonal</param> 
    /// <param name="animator">Controlador de parâmetros de animação do objeto</param>
    /// <param name="rb">Determinador da posição do objeto em tempo real</param>

    [Header("Movement")]
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    private bool isMoving;
    private bool isRunning;
    private Vector2 input;
    private Animator animator;
    private Rigidbody2D rb;

    /// <summary>
    /// "Combat Settings"é referente ao ponto de contato
    /// </summary>
    /// <param name="attackPoint">Permite o acesso ao parâmetros do Transform</param>
    /// <param name="attackRange">Raio do Collider</param>
    /// <param name="target">Permite o acesso às Layers do editor</param>
    
    [Header("Combat Settings")]
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask target;

    /// <summary>
    /// "Abilities Damage" contém todas as variáveis associadas ao combate
    /// </summary>
    /// <param name="_jab">Habilidade ativável com a tecla Alpha 1</param>
    /// <param name="_cross">Habilidade ativável com a tecla Alpha 2</param>
    /// <param name="_megaCross">Habilidade ativável com a tecla Alpha 3</param>
    /// <param name="_wise">Habilidade temporária ativável com a tecla Alpha 4</param>
    
    [Header("Abilities Damage")]
    [SerializeField] private float _jab;
    [SerializeField] private float _cross;
    [SerializeField] private float _megaCross;
    [SerializeField] private float _wise;

    /// <summary>
    /// "Charge" corresponde à verificação de ativáveis
    /// </summary>
    /// <param name = "isWise">Boolean que verifica se a habilidade "_wise" está ativa</param>

    [Header("Charge")]
    public bool isWise;

    
    
    // Start é chamado no primeiro frame quando o script é iniciado
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    

    // Update é executado em cada frame
    void Update()
    {
        /// <summary>
        /// Condição que executa sempre que existir movimento do Player
        /// </summary>

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal"); // Valor obtido no movimento usado pelas teclas A e D e pelas setas esquerda e direita
            input.y = Input.GetAxisRaw("Vertical"); // Valor obtido no movimento usado pelas teclas W e S e pelas setas cima e baixo
 
            /// <summary>
            /// Esta condição impede o movimento diagonal
            /// </summary>

            if (input.x != 0) input.y = 0;

            /// <summary>
            /// Condição que é executada se o valor registado é diferente de Vector2(0,0), isto é, a última posição registada do objeto
            /// </summary>

            if (input != Vector2.zero)
            {
                // Se o booleano "isRunning" for verdadeiro, então é atribuído ao "speed" o valor da velocidade atribuída à variável "_runSpeed"
                // Caso "isRunning" seja falso, então o valor atribuído ao "speed" é o valor da velocidade atribuído à variável "_walkSpeed"
                float speed = isRunning ? _runSpeed : _walkSpeed;

                // Mudança da posição do objeto, onde a posição atual e a velocidade são somadas ao produto entre o intervalo de tempo e o valor gerado pelo movimento
                rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * input);
                

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
        }

        if (animator.GetBool("isDead") == true)
        {
            
            animator.SetFloat("speed", 0);
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

        /// <summary>
        /// Métodos associados aos ataques, atribuídos às teclas Alpha 1, 2, 3 e 4
        /// </summary>

        if (Input.GetKeyDown(KeyCode.Alpha1)) Jab();
        
        if (Input.GetKeyDown(KeyCode.Alpha2)) Cross();

        if (Input.GetKeyDown(KeyCode.Alpha3)) MegaCross();

        if (Input.GetKeyDown(KeyCode.Alpha4)) Wise();

        animator.SetBool("isWise", false);
    }

    /// <summary>
    /// Jab é executado sempre que o utlizador pressiona a tecla Alpha 1
    /// A animação do Jab é ativa, atribuído o 
    /// </summary>

    public void Jab()
    {
        animator.SetTrigger("Jab");

        if (isWise) Debug.Log("Jab Wise");
        else Debug.Log("Jab");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().health -= _jab;
            Debug.Log("Enemy hit");
        }
    }

    public void Cross()
    {
        animator.SetTrigger("Cross");

        if (isWise) Debug.Log("Cross Wise");
        else Debug.Log("Cross");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().health -= _cross;
            Debug.Log("Enemy hit");
        }
    }

    public void MegaCross()
    {
        animator.SetTrigger("MegaCross");

        if (isWise)
            Debug.Log("Mega Cross Wise");
        else
            Debug.Log("Mega Cross");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target);

        foreach (Collider2D enemy in enemies)
        {
            Debug.Log("Enemy hit");
            enemy.GetComponent<EnemyHealth>().health -= _megaCross;
        }
    }

    public void Wise()
    {
        animator.SetTrigger("Wise");
        animator.SetBool("isWise", isWise);

        Debug.Log("Wise");

        StartCoroutine(ResetWise());
        StartCoroutine(StartWise());
    }

    IEnumerator StartWise()
    {
        yield return new WaitForSeconds(2);

        animator.SetLayerWeight(1, 1);

        isWise = true;

        _jab *= _wise;
        _cross *= _wise;
        _megaCross *= _wise;
    }

    IEnumerator ResetWise()
    {
        yield return new WaitForSeconds(20);

        animator.SetLayerWeight(1, 0);

        isWise = false;

        _jab /= _wise;
        _cross /= _wise;
        _megaCross /= _wise;
    }

    /// <summary>
    /// Desenha no editor uma esfera do objeto "attackPoint" com o raio = "attackRange"
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    
}