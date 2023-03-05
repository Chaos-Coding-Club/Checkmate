using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public static GameObject controller;

    public static GameObject reference = null;

    public static string[] nameArray = new string[64];

    int matrixX;
    int matrixY;

    public bool attack = false;
    public bool castle;

    public void Start(){
        if (attack){
            
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
           
        }
    }

    public void OnMouseUp() {

        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack){
            GameObject piece = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);

            string Attacked = piece.name;
            PlayerPrefs.SetString("Attacked", Attacked);

            string Attacker = reference.name;
            PlayerPrefs.SetString("Attacker", Attacker);

            // Debug.Log("piece: " + piece.name);
            // Debug.Log(reference);

            DontDestroyOnLoad(controller);
            
            int count = 0;

            for(int i = 0; i < 8; i++){
                for(int j = 0; j < 8; j++){
                    if(controller.GetComponent<Game>().GetPosition(j,i)){
                        //Debug.Log(controller.GetComponent<Game>().GetPosition(i,j).GetComponent<Chessman>().name);
                        nameArray[count] = controller.GetComponent<Game>().GetPosition(j,i).GetComponent<Chessman>().name;
                        print(nameArray[count]);
                    }
                    count++;
                }
            }

            PlayerPrefs.SetInt("arraySpot", 8*matrixY+matrixX);
            PlayerPrefs.SetInt("eraseSpot", 8*reference.GetComponent<Chessman>().GetYBoard()+reference.GetComponent<Chessman>().GetXBoard());


            controller.GetComponent<Game>().LoadArena();

            Destroy(piece);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Chessman>().GetXBoard(),
            reference.GetComponent<Chessman>().GetYBoard());

        if(castle){
            GameObject piece = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            piece.GetComponent<Chessman>().SetXBoard(4);
            piece.GetComponent<Chessman>().SetYBoard(matrixY);
            piece.GetComponent<Chessman>().SetCoords();
            controller.GetComponent<Game>().SetPosition(piece);
            Debug.Log(controller.GetComponent<Game>().GetPosition(4, matrixY));
        }


        reference.GetComponent<Chessman>().SetXBoard(matrixX);
        reference.GetComponent<Chessman>().SetYBoard(matrixY);
        reference.GetComponent<Chessman>().SetCoords();

        if(reference.GetComponent<Chessman>().hasMoved == false) reference.GetComponent<Chessman>().hasMoved = true;


        controller.GetComponent<Game>().SetPosition(reference);

        
        
        controller.GetComponent<Game>().NextTurn();

        reference.GetComponent<Chessman>().DestroyMovePlates();

    }

    public void SetCoords(int x, int y){
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj){
        reference = obj;
    }

    public GameObject GetReference(){
        return reference;
    }

}
