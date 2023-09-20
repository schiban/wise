using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died");
        }
    }
}
