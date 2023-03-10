using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{

    public static Game instance;

    public GameObject chessPiece;

    public static GameObject[,] position = new GameObject[8,8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];
    public static string currentPlayer = "white";
    public bool check = false;
    public int[] blackKingLoc = new int[2] {4,7};
    public int[] whiteKingLoc = new int[2] {4,0};
    public static bool firstLoad = true;
    private bool gameOver = false;
    // Start is called before the first frame update

    // private void Awake() {
    //     instance = this;

    //     //DontDestroyOnLoad(this.gameObject);
    // }
    void Start()
    {
        if(firstLoad ==true){
            playerWhite = new GameObject[] { 
                Create("white_rook", 0, 0, false), 
                Create("white_knight", 1, 0, false),
                Create("white_bishop", 2, 0, false),
                Create("white_queen", 3, 0, false),
                Create("white_king", 4, 0, false),
                Create("white_bishop", 5, 0, false),
                Create("white_knight", 6, 0, false),
                Create("white_rook", 7, 0, false),
                Create("white_pawn", 0, 1, false),
                Create("white_pawn", 1, 1, false),
                Create("white_pawn", 2, 1, false),
                Create("white_pawn", 3, 1, false),
                Create("white_pawn", 4, 1, false),
                Create("white_pawn", 5, 1, false),
                Create("white_pawn", 6, 1, false),
                Create("white_pawn", 7, 1, false)};
            
            playerBlack = new GameObject[] { 
                Create("black_rook", 0, 7, false), 
                Create("black_knight", 1, 7, false),
                Create("black_bishop", 2, 7, false),
                Create("black_queen", 3, 7, false),
                Create("black_king", 4, 7, false),
                Create("black_bishop", 5, 7, false),
                Create("black_knight", 6, 7, false),
                Create("black_rook", 7, 7, false),
                Create("black_pawn", 0, 6, false),
                Create("black_pawn", 1, 6, false),
                Create("black_pawn", 2, 6, false),
                Create("black_pawn", 3, 6, false),
                Create("black_pawn", 4, 6, false),
                Create("black_pawn", 5, 6, false),
                Create("black_pawn", 6, 6, false),
                Create("black_pawn", 7, 6, false)};

            for(int i = 0; i < playerWhite.Length; i++)
            {
                SetPosition(playerBlack[i]);
                SetPosition(playerWhite[i]);
            }
        }
        else{
            int count = 0;
            for(int i = 0; i < 8; i++){
                for(int j = 0; j < 8; j++){
                    //print(MovePlate.nameArray[count]);
                    if(MovePlate.nameArray[count] == "white_rook"){
                        Create("white_rook", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "white_bishop"){
                        Create("white_bishop", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "white_knight"){
                        Create("white_knight", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "white_queen"){
                        Create("white_queen", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "white_king"){
                        Create("white_king", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "white_pawn"){
                        //Debug.Log("please");
                        Create("white_pawn", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "black_rook"){
                        Create("black_rook", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "black_bishop"){
                        Create("black_bishop", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "black_knight"){
                        Create("black_knight", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "black_queen"){
                        Create("black_queen", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "black_king"){
                        Create("black_king", count % 8, count / 8, false);
                    }
                    else if(MovePlate.nameArray[count] == "black_pawn"){
                        //Debug.Log("please");
                        Create("black_pawn", count % 8, count / 8, false);
                    }
                    count++;
    
                }
            }
            //Debug.Log(count);
        }
        firstLoad = false;
    }

    public GameObject Create(string name, int x, int y, bool hasMoved)
    {
        GameObject obj = Instantiate(chessPiece, new Vector3(0,0, -1), Quaternion.identity);
        Chessman cm = obj.GetComponent<Chessman>();
        cm.name = name;
        cm.SetXBoard(x);
        cm.SetYBoard(y);
        cm.hasMoved = hasMoved;
        cm.Activate();
        return obj;
    }

    public void SetPosition(GameObject obj) {
        Chessman cm = obj.GetComponent<Chessman>();
        position[cm.GetXBoard(), cm.GetYBoard()] = obj;
    }

    public void SetPositionEmpty(int x, int y){
        position[x,y] = null;
    }

    public GameObject GetPosition(int x, int y){
        return position[x,y];
    }

    public bool PositionOnBoard(int x, int y){
        if(x < 0 || y < 0 || x >= position.GetLength(0) || y >= position.GetLength(1)) return false;
        return true;
    }

    public string GetCurrentPlayer(){
        return currentPlayer;
    }

    public bool IsGameOver(){
        return gameOver;
    }

    public static void NextTurn(){
        if(currentPlayer == "white"){
            currentPlayer = "black";
        }
        else currentPlayer = "white";
    }

    public void Update(){
        if(gameOver == true && Input.GetMouseButtonDown(0)){
            gameOver = false;

            SceneManager.LoadScene("Game");
        }
    }

    public void LoadArena(){
        SceneManager.LoadScene("Fighting Game/Scenes/FightScene");
    }

}
