using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 90;
    [SerializeField] private Animator animator;
    private int currentHealth;
    public int attackDamage = 10;


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
