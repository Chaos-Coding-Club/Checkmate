using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 75;
    [SerializeField] private Animator animator;
    private int currentHealth;
    public int attackDamage = 8;


    // Update is called once per frame
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        // play hurt animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        Destroy(this);
    }
}
