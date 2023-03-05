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

    private void Start()
    {
        string attacker = PlayerPrefs.GetString("Attacker");
        string attacked = PlayerPrefs.GetString("Attacked");
        if (attacker.StartsWith("white"))
        {
            currentPiece = attacked;
            enemyPiece = attacker;
        }
        else
        {
            currentPiece = attacker;
            enemyPiece = attacked;
        }
    }
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
                case "white_pawn":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Knight
                case "white_knight":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Bishop
                case "white_bishop":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Rook
                case "white_rook":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Queen
                case "white_queen":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // King
                case "white_king":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
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
                case "white_pawn":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<PawnStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Knight
                case "white_knight":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<KnightStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Bishop
                case "white_bishop":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<BishopStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Rook
                case "white_rook":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<RookStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // Queen
                case "white_queen":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<QueenStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;
                // King
                case "white_king":
                    switch (currentPiece)
                    {
                        // Pawn
                        case "black_pawn":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<PawnStats>().attackDamage);
                            break;
                        // Knight
                        case "black_knight":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<KnightStats>().attackDamage);
                            break;
                        // Bishop
                        case "black_bishop":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<BishopStats>().attackDamage);
                            break;
                        // Rook
                        case "black_rook":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<RookStats>().attackDamage);
                            break;
                        // Queen
                        case "black_queen":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<QueenStats>().attackDamage);
                            break;
                        // King
                        case "black_king":
                            c.GetComponent<KingStats>().TakeDamage(GetComponent<KingStats>().attackDamage);
                            break;
                    }
                    break;

            }
        }
    }
}
