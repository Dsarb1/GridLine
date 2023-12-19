using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;

    GameObject reference = null;

    int matrixX;
    int matrixY;

    public bool attack = false;

    //changes color of piece when attacking
    public void Start()
    {
        if (attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }
    //when user releases mouse button moves game piece to next place on tile map selected by user
    public void OnMouseUp()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        if (attack)
        {
            GameObject cp = controller.GetComponent<GameSetup>().GetPosition(matrixX, matrixY);

            Destroy(cp);
        }

        controller.GetComponent<GameSetup>().SetPositionEmpty(reference.GetComponent<Pieces>().GetXBoard(),
            reference.GetComponent<Pieces>().GetYBoard());

        reference.GetComponent<Pieces>().SetXBoard(matrixX);
        reference.GetComponent<Pieces>().SetYBoard(matrixY);
        reference.GetComponent<Pieces>().SetCoords();

        controller.GetComponent<GameSetup>().SetPosition(reference);

        reference.GetComponent<Pieces>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }

}
