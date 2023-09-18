using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

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

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() // Update() é chamado uma vez por frame
    {
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
