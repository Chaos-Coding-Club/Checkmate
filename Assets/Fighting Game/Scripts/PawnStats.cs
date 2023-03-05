using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    private int currentHealth;
    [SerializeField] private int damage = 30;


    // Update is called once per frame
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
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
