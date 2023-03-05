using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Combat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform punchPoint;
    [SerializeField] private float punchRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;


    private string[] pieces = { "pawn", "knight", "bishop", "rook", "queen", "king" };
    [SerializeField] int currentPiece;

    void Update()
    {
        if (Input.GetButtonDown("Fire1P1"))
        {
            Punch();
        }

        if (Input.GetButtonDown("Fire2P1"))
        {
            Kick();
        }

    }
    private void OnDrawGizmosSelected()
    {
        if (punchPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(punchPoint.position, punchRange);

    }

    void Punch()
    {
        animator.SetTrigger("Punch");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(punchPoint.position, punchRange, enemyLayers);
        foreach(Collider2D c in hitEnemies)
        {
            switch (currentPiece)
            {
                case 0:
                    c.GetComponent<PawnStats>().TakeDamage();
                    break;
                case 1:
                    c.GetComponent<PawnStats>().TakeDamage();
                    break;

            }
        }
    }

    void Kick()
    {
        animator.SetTrigger("Kick");
    }
}
