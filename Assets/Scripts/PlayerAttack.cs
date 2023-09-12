using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Definições")]
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemies;
    public bool isWise;
    public float radius = 1f;
    public float jabDamage; private float jab;
    public float crossDamage; private float cross;
    public float megaCrossDamage; private float megaCross;
    public float wiseDamage;

    void Start() // Start() é chamado no primeiro frame quando o script é iniciado
    {
        animator = GetComponent<Animator>();
        jab = jabDamage;
        cross = crossDamage;
        megaCross = megaCrossDamage;
    }

    // Update is called once per frame
    void Update() // Update() é chamado uma vez por frame
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

    public void Jab()
    {
        animator.SetTrigger("Jab");
        if (isWise)
        {
            Debug.Log("Jab Wise");
            jab *= wiseDamage;
        }
        else
            Debug.Log("Jab");

        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Enemy hit");
            enemyGameObject.GetComponent<EnemyHealth>().health -= jab;
        }
    }

    public void Cross()
    {
        animator.SetTrigger("Cross");
        if (isWise)
        {
            Debug.Log("Cross Wise");
            cross *= wiseDamage;
        }
        else
            Debug.Log("Cross");

        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Enemy hit");
            enemyGameObject.GetComponent<EnemyHealth>().health -= cross;
        }
    }

    public void MegaCross()
    {
        animator.SetTrigger("MegaCross");
        if (isWise)
        {
            Debug.Log("Mega Cross Wise");
            megaCross *= wiseDamage;
        }
        else
            Debug.Log("Mega Cross");

        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Enemy hit");
            enemyGameObject.GetComponent<EnemyHealth>().health -= megaCross;
        }
    }

    public void Wise()
    {
        animator.SetTrigger("Wise");
        isWise = true;
        animator.SetBool("isWise", isWise);
        Debug.Log("Wise");
        StartCoroutine(ResetWise());
        StartCoroutine(wiseAnimation());
    }

    IEnumerator wiseAnimation()
    {
        yield return new WaitForSeconds(2);
        animator.SetLayerWeight(1, 1);
    }

    IEnumerator ResetWise()
    {
        yield return new WaitForSeconds(20);
        animator.SetLayerWeight(1, 0);
        isWise = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }
}
