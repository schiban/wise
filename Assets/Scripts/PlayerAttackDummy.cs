using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackDummy : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;
    
    [Header("Combat Settings")]
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask target;
    
    [Header("Abilities Damage")]
    [SerializeField] private float _jab;
    [SerializeField] private float _cross;
    [SerializeField] private float _megaCross;
    [SerializeField] private float _wise;
    public bool isWise;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Jab();
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Cross();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            MegaCross();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            Wise();

        animator.SetBool("isWise", false);
    }

    /// <summary>
    /// Jab é executado sempre que o utlizador pressiona a tecla Alpha 1
    /// </summary>

    public void Jab()
    {
        animator.SetTrigger("Jab");

        if (isWise)
            Debug.Log("Jab Wise");
        else
            Debug.Log("Jab");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Dummy>().health -= _jab;
            Debug.Log("Enemy hit");
        }
    }

    /// <summary>
    /// Cross é executado sempre que o utlizador pressiona a tecla Alpha 2
    /// </summary>
    public void Cross()
    {
        animator.SetTrigger("Cross");

        if (isWise)
            Debug.Log("Cross Wise");
        else
            Debug.Log("Cross");

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Dummy>().health -= _cross;
            Debug.Log("Enemy hit");
        }
    }

    /// <summary>
    /// MegaCross é executado sempre que o utlizador pressiona a tecla Alpha 3
    /// </summary>
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
            enemy.GetComponent<Dummy>().health -= _megaCross;
        }
    }

    /// <summary>
    /// Wise é ativo sempre que o utlizador pressiona a tecla Alpha 4
    /// </summary>
    public void Wise()
    {
        animator.SetTrigger("Wise");
        animator.SetBool("isWise", isWise);

        Debug.Log("Wise");

        StartCoroutine(ResetWise());
        StartCoroutine(StartWise());
    }

    /// <summary>
    /// Wise é ativo sempre que o utlizador pressiona a tecla Alpha 4 com duração de 2 segundos
    /// </summary>
    /// <remarks>
    /// Passados 2 segundos, no animator, é trocada a camada para as animações com o Wise ativo.
    /// Estando o Wise ativo, então o valor das habilidades é aumentado.
    /// </remarks>
    IEnumerator StartWise()
    {
        yield return new WaitForSeconds(2);

        animator.SetLayerWeight(1, 1);

        isWise = true;

        _jab *= _wise;
        _cross *= _wise;
        _megaCross *= _wise;
    }

    /// <summary>
    /// Finalização do power-up que tem 20 segundos
    /// </summary>
    /// <remarks>
    /// Passados 20 segundos depois, no animator, é trocada a camada para as animações sem a chama.
    /// Estando o Wise inativo, então o valor das habilidades voltam ao normal.
    /// </remarks>
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
    /// Desenha no editor uma esfera do objeto attackPoint com o raio = attackRange
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
