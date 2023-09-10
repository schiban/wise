using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
    }
}
