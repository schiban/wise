using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerHealth healthManager;
    public Slider healthBar;

    void Awake()
    {
        healthManager = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.health;
    }
}
