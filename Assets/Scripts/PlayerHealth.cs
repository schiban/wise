using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;
    private RespawnPoint respawn;

    [Header("Player Health")]
    public float health;
    public float maxHealth;
    public bool isDead;

    void Awake()
    {
        animator = GetComponent<Animator>();
        respawn = FindObjectOfType<RespawnPoint>();
    }

    void Start()
    {
        health = maxHealth;
    }

    /// <summary>
    /// Atualiza a vida do protagonista
    /// </summary>
    /// <param name="damageToGive">Dano recebido por um inimigo</param>
    /// <param name="health">Vida do protagonista</param>
    /// <param name="animator">Controlador de parâmetros do Animator</param>
    /// <param name="isDead">Vivo ou morto</param>
    /// <param name="respawn">Ativa o ecrã de recomeçar</param>
    public void HurtPlayer(int damageToGive)
    {
        animator.SetTrigger("Hit");
        health -= damageToGive;

        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            isDead = true;
            respawn.RespawnScene();
        }
    }
}
