using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Combat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform punchPoint;
    [SerializeField] private float punchRange = 0.5f;
    [SerializeField] private Transform kickPoint;
    [SerializeField] private float kickRange = 0.5f;
    [SerializeField] private LayerMask enemyLayers;

    [SerializeField] string currentPiece;
    [SerializeField] string enemyPiece;

    void Update()
    {
        if (Input.GetButtonDown("Fire1P2"))
        {
            Punch();
        }

        if (Input.GetButtonDown("Fire2P2"))
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
        foreach (Collider2D c in hitEnemies)
        {
            switch (enemyPiece)
            {
                // Pawn
                case "black_pawn":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Knight
                case "black_knight":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Bishop
                case "black_bishop":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Rook
                case "black_rook":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Queen
                case "black_queen":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // King
                case "black_king":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;

            }
        }
    }

    void Kick()
    {
        animator.SetTrigger("Kick");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        foreach (Collider2D c in hitEnemies)
        {
            switch (enemyPiece)
            {
                // Pawn
                case "black_pawn":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Knight
                case "black_knight":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Bishop
                case "black_bishop":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Rook
                case "black_rook":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Queen
                case "black_queen":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // King
                case "black_king":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "white_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "white_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "white_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "white_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "white_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "white_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;

            }
        }
    
    }
}
