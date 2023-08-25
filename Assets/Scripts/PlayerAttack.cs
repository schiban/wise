using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public float cooldown;
    public bool isWise;

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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

    public void Jab()
    {
        animator.SetTrigger("Jab");
        if (isWise)
            Debug.Log("Jab Wise");
        else
            Debug.Log("Jab");

        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Enemy hit");
        }
    }

    public void Cross()
    {
        animator.SetTrigger("Cross");
        if (isWise)
            Debug.Log("Cross Wise");
        else
            Debug.Log("Cross");
    }

    public void MegaCross()
    {
        animator.SetTrigger("MegaCross");
        if (isWise)
            Debug.Log("Mega Cross Wise");
        else
            Debug.Log("Mega Cross");
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
}
