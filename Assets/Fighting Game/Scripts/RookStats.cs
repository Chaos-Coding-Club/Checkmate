using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 75;
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
        // Die animation
        // Disable enemy
        print("Player is dead.");
    }
}
