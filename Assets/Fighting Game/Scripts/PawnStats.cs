using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PawnStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    [SerializeField] private Animator animator;
    public int currentHealth;
    public int attackDamage = 7;


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
        LoadBoard();
    }

    public void LoadBoard(){
        SceneManager.LoadScene("Chess Game/Scenes/SampleScene");
    }
}
