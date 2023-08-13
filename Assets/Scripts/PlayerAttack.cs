using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public float cooldown;
    public bool isWise;

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

    void Jab()
    {
        animator.SetTrigger("Jab");
        if (isWise)
            Debug.Log("Jab Wise");
        else
            Debug.Log("Jab");
    }

    void Cross()
    {
        animator.SetTrigger("Cross");
        if (isWise)
            Debug.Log("Cross Wise");
        else
            Debug.Log("Cross");
    }

    void MegaCross()
    {
        animator.SetTrigger("MegaCross");
        if (isWise)
            Debug.Log("Mega Cross Wise");
        else
            Debug.Log("Mega Cross");
    }

    void Wise()
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
        yield return new WaitForSeconds(30);
        animator.SetLayerWeight(1, 0);
        isWise = false;
    }
}
