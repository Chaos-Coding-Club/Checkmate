using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KingStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Animator animator;
    public int currentHealth;
    public int attackDamage = 15;


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
        int spot = PlayerPrefs.GetInt("arraySpot");
        int erase = PlayerPrefs.GetInt("eraseSpot");
        MovePlate.nameArray[erase] = null;
        if (this.name.StartsWith("White"))
        {
            MovePlate.nameArray[spot] = Player1Combat.enemyPiece;
        }
        else
        {
            MovePlate.nameArray[spot] = Player1Combat.currentPiece;
        }


        Destroy(this);

        LoadBoard();
    }

    public void LoadBoard()
    {
        SceneManager.LoadScene("Chess Game/Scenes/SampleScene");
    }
}
