using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private float waitToLoad = 2f;
    private bool reloading;
    public int damageToGive = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            // EnemyHealthManager healthManager;
            // healthManager = other.gameObject.GetComponent<EnemyHealthManager>();
            // healthManager.HurtEnemy(damageToGive);
            other.gameObject.SetActive(false);
            reloading = true;
        }
    }
}
