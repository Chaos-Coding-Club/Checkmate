using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    static public GameObject controller;

    GameObject reference = null;

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