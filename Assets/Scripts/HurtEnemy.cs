using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            EnemyHealthManager healthManager;
            healthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            healthManager.HurtEnemy(damageToGive);
        }
    }
}
