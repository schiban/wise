using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;

    private HealthManager healthManager;
    private float waitToHurt = 2f;
    private bool isTouching;

    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        healthManager = FindObjectOfType<HealthManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitToHurt-= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                Cross();
                waitToHurt = 2f;
            }
        }
    }

    public void Cross()
    {
        animator.SetTrigger("Cross");
        healthManager.HurtPlayer(damageToGive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = true;
            waitToHurt = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
