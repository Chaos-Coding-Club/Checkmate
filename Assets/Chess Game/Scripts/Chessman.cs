using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
   public GameObject controller;
   public GameObject movePlate;

   private int xBoard = -1;
   private int yBoard = -1;

   public bool hasMoved;

   private string player;

   public Sprite black_king, black_queen, black_knight, black_bishop, black_rook, black_pawn;
   public Sprite white_king, white_queen, white_knight, white_bishop, white_rook, white_pawn;

   public void Activate()
   {
        controller = GameObject.FindGameObjectWithTag("GameController");

        SetCoords();

        switch (this.name)
        {
            case "black_queen": this.GetComponent<SpriteRenderer>().sprite = black_queen; player = "black"; break;
            case "black_knight": this.GetComponent<SpriteRenderer>().sprite = black_knight; player = "black"; break;
            case "black_bishop": this.GetComponent<SpriteRenderer>().sprite = black_bishop; player = "black"; break;
            case "black_king": this.GetComponent<SpriteRenderer>().sprite = black_king; player = "black"; break;
            case "black_rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; player = "black"; break;
            case "black_pawn": this.GetComponent<SpriteRenderer>().sprite = black_pawn; player = "black"; break;

            case "white_queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; player = "white"; break;
            case "white_knight": this.GetComponent<SpriteRenderer>().sprite = white_knight; player = "white"; break;
            case "white_bishop": this.GetComponent<SpriteRenderer>().sprite = white_bishop; player = "white"; break;
            case "white_king": this.GetComponent<SpriteRenderer>().sprite = white_king; player = "white"; break;
            case "white_rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; player = "white"; break;
            case "white_pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; player = "white"; break;

        }
   }

    public void SetCoords(){
        float x = xBoard;
        float y = yBoard;

        x *= 1.226f;
        y *= 1.226f;

        x += -4.275f;
        y += -4.275f;

        this.transform.position = new Vector3 (x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }

    private void OnMouseUp(){ 
        if(!controller.GetComponent<Game>().IsGameOver() && controller.GetComponent<Game>().GetCurrentPlayer() == player){
            DestroyMovePlates();

            InitiateMovePlates();
        }
    }

    public void DestroyMovePlates(){
        GameObject[] movePlates = GameObject.FindGameObjectsWithTag("MovePlate");
        for(int i = 0; i < movePlates.Length; i++){
            Destroy(movePlates[i]);
        }
    }

    public void InitiateMovePlates(){
        switch (this.name){
            case "black_queen":
            case "white_queen":
                LineMovePlate(1,0, false);
                LineMovePlate(0,1, false);
                LineMovePlate(1,1, false);
                LineMovePlate(-1,0, false);
                LineMovePlate(0,-1, false);
                LineMovePlate(-1,-1, false);
                LineMovePlate(-1,1, false);
                LineMovePlate(1,-1, false);
                break;
            
            case "black_knight":
            case "white_knight":
                LMovePlate();
                break;

            case "black_bishop":
            case "white_bishop":
                LineMovePlate(1,1, false);
                LineMovePlate(1,-1, false);
                LineMovePlate(-1,1, false);
                LineMovePlate(-1,-1, false);
                break;
            
            case "black_king":
            case "white_king":
                SurroundMovePlate();
                break;

            case "black_rook":
            case "white_rook":
                LineMovePlate(1,0, false);
                LineMovePlate(0,1, false);
                LineMovePlate(-1,0, false);
                LineMovePlate(0,-1, false);
                break;

            case "black_pawn":
                PawnMovePlate(xBoard, yBoard-1);
                break;

            case "white_pawn":
                PawnMovePlate(xBoard, yBoard+1);
                break;
        }
    }

    public bool LineMovePlate(int xIncrement, int yIncrement, bool checkTest){
        Game sc = controller.GetComponent<Game>();

        int x = xBoard + xIncrement;
        int y = yBoard + yIncrement;

        while(sc.PositionOnBoard(x,y) && sc.GetPosition(x,y) == null && !checkTest){
            MovePlateSpawn(x,y);
            x+= xIncrement;
            y += yIncrement;
        }

        if(sc.PositionOnBoard(x,y) && sc.GetPosition(x,y).GetComponent<Chessman>().player != player){
            if(!checkTest){
                MovePlateAttackSpawn(x,y);
            } 
            else{
                return true;
            }
        }

        return false;
    }

    public void LMovePlate(){
        PointMovePlate(xBoard + 1, yBoard + 2);
        PointMovePlate(xBoard - 1, yBoard + 2);
        PointMovePlate(xBoard + 2, yBoard + 1);
        PointMovePlate(xBoard + 2, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard - 2);
        PointMovePlate(xBoard - 1, yBoard - 2);
        PointMovePlate(xBoard - 2, yBoard + 1);
        PointMovePlate(xBoard - 2, yBoard - 1);
    }

    public void SurroundMovePlate(){
        PointMovePlate(xBoard, yBoard + 1);
        PointMovePlate(xBoard, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard + 1);
        PointMovePlate(xBoard - 1, yBoard - 1);
        PointMovePlate(xBoard + 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard);
        PointMovePlate(xBoard - 1, yBoard + 1);
        PointMovePlate(xBoard + 1, yBoard - 1);
    }

    public void PointMovePlate(int x, int y){
        Game sc =controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x, y)){
            GameObject piece = sc.GetPosition(x, y);

            if(piece == null){
                MovePlateSpawn(x, y);
            }
            else if(piece.GetComponent<Chessman>().player != player)
            {
                MovePlateAttackSpawn(x, y);
            }
        }
    }

    public void PawnMovePlate(int x, int y){
        Game sc = controller.GetComponent<Game>();
        if(sc.PositionOnBoard(x,y)){
            if(sc.GetPosition(x,y) == null){
                MovePlateSpawn(x,y);
                if(this.GetComponent<Chessman>().hasMoved == false && this.GetComponent<Chessman>().GetYBoard() == 1 && sc.GetPosition(x, y+1) == null){
    
                    MovePlateSpawn(x,y+1);
                }
                else if(this.GetComponent<Chessman>().hasMoved == false && this.GetComponent<Chessman>().GetYBoard() == 6 && sc.GetPosition(x, y-1) == null){
                    MovePlateSpawn(x,y-1);
                }
                
            }

            if(sc.PositionOnBoard(x + 1,y) && sc.GetPosition(x+1, y) != null && sc.GetPosition(x+1, y).GetComponent<Chessman>().player != player){
                MovePlateAttackSpawn(x+1,y);
            }

            if(sc.PositionOnBoard(x - 1,y) && sc.GetPosition(x-1, y) != null && sc.GetPosition(x-1, y).GetComponent<Chessman>().player != player){
                MovePlateAttackSpawn(x-1,y);
            }
        }
    }

    public void MovePlateSpawn(int matrixX, int matrixY){
        float x = matrixX;
        float y =matrixY;

        x *= 1.226f;
        y *= 1.226f;

        x += -4.275f;
        y += -4.275f;

        GameObject mp = Instantiate(movePlate, new Vector3(x,y, -3.0f),  Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    public void MovePlateAttackSpawn(int matrixX, int matrixY){
        float x = matrixX;
        float y =matrixY;

        x *= 1.226f;
        y *= 1.226f;

        x += -4.275f;
        y += -4.275f;

        GameObject mp = Instantiate(movePlate, new Vector3(x,y, -3.0f),  Quaternion.identity);

        MovePlate mpScript = mp.GetComponent<MovePlate>();
        mpScript.attack = true;
        mpScript.SetReference(gameObject);
        mpScript.SetCoords(matrixX, matrixY);
    }

    
}

