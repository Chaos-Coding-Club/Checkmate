using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderPieces : MonoBehaviour
{
    [SerializeField] private GameObject black_king, black_queen, black_knight, black_bishop, black_rook, black_pawn;
    [SerializeField] private GameObject white_king, white_queen, white_knight, white_bishop, white_rook, white_pawn;
    private string currentPiece;
    private string enemyPiece;

    void Start()
    {
        string attacker = PlayerPrefs.GetString("Attacker");
        string attacked = PlayerPrefs.GetString("Attacked");

        if (attacker.StartsWith("white"))
        {
            currentPiece = attacker;
            enemyPiece = attacked;
        }
        else
        {
            currentPiece = attacked;
            enemyPiece = attacker;
        }

        switch (currentPiece)
        {
            case "black_queen": Instantiate(black_queen); break;
            case "black_knight": Instantiate(black_knight); break;
            case "black_bishop": Instantiate(black_bishop); break;
            case "black_king": Instantiate(black_king); break;
            case "black_rook": Instantiate(black_rook); break;
            case "black_pawn": Instantiate(black_pawn); break;

            case "white_queen": Instantiate(white_queen); break;
            case "white_knight": Instantiate(white_knight); break;
            case "white_bishop": Instantiate(white_bishop); break;
            case "white_king": Instantiate(white_king); break;
            case "white_rook": Instantiate(white_rook); break;
            case "white_pawn": Instantiate(white_pawn); break;
        }
        switch (enemyPiece)
        {
            case "black_queen": Instantiate(black_queen); break;
            case "black_knight": Instantiate(black_knight); break;
            case "black_bishop": Instantiate(black_bishop); break;
            case "black_king": Instantiate(black_king); break;
            case "black_rook": Instantiate(black_rook); break;
            case "black_pawn": Instantiate(black_pawn); break;

            case "white_queen": Instantiate(white_queen); break;
            case "white_knight": Instantiate(white_knight); break;
            case "white_bishop": Instantiate(white_bishop); break;
            case "white_king": Instantiate(white_king); break;
            case "white_rook": Instantiate(white_rook); break;
            case "white_pawn": Instantiate(white_pawn); break;
        }
    }
}
