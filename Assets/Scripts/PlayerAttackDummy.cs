using System.Collections;
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
    [SerializeField] private float jab;
    [SerializeField] private float cross;
    [SerializeField] private float megaCross;
    [SerializeField] private float wise;
    public bool isWise;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(animator.GetBool("isDead") == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                PerformAttack("Jab", jab);
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                PerformAttack("Cross", cross);

            if (Input.GetKeyDown(KeyCode.Alpha3))
                PerformAttack("MegaCross", megaCross);

            if (Input.GetKeyDown(KeyCode.Alpha4))
                Wise("Wise");
        }
        animator.SetBool("isWise", false);
    }

    public void PerformAttack(string attack, float damage)
    {
        animator.SetTrigger(attack);

        if (isWise)
            Debug.Log(attack + " Wise");
        else
            Debug.Log(attack);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, target);

        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<Dummy>().health -= damage;
            Debug.Log("Enemy hit");
        }
    }

    /// <summary>
    /// Wise é ativo sempre que o utlizador pressiona a tecla Alpha 4
    /// </summary>
    public void Wise(string attack)
    {
        animator.SetTrigger(attack);
        animator.SetBool("isWise", isWise);
        Debug.Log(attack);

        StartCoroutine(WiseDuration());
    }

    /// <summary>
    /// Controlo do tempo de duração do powerup
    /// </summary>
    /// <remarks>
    /// Passados 2 segundos, no animator, é trocada a camada para as animações com o Wise ativo.
    /// Estando o Wise ativo, então o valor das habilidades é aumentado.
    /// Passados 20 segundos depois, no animator, é trocada a camada para as animações sem a chama.
    /// Estando o Wise inativo, então o valor das habilidades voltam ao normal.
    /// </remarks>
    IEnumerator WiseDuration()
    {
        yield return new WaitForSeconds(2);
        animator.SetLayerWeight(1, 1);
        isWise = true;
        jab *= wise;
        cross *= wise;
        megaCross *= wise;

        yield return new WaitForSeconds(20);
        animator.SetLayerWeight(1, 0);
        isWise = false;
        jab /= wise;
        cross /= wise;
        megaCross /= wise;
    }

    /// <summary>
    /// Desenha no editor uma esfera do objeto attackPoint com o raio = attackRange
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
