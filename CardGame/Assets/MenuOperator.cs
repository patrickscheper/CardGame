using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOperator : MonoBehaviour
{

    public GameObject myDeckCanvas;
    public GameObject StoreCanvas;

    public GameDeckDataBase dataBase;
    public GameDeckOperator deckOperator;

    // Use this for initialization
    void Awake()
    {
        dataBase = GetComponent<GameDeckDataBase>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchCanvas(bool i)
    {
        if (i)
        {
            myDeckCanvas.SetActive(i);
            StoreCanvas.SetActive(!i);

            return;
        }
        myDeckCanvas.SetActive(i);
        StoreCanvas.SetActive(!i);

    }

    public void GetBronze()
    {

        deckOperator.cardDeck.Add(dataBase.cardDeckNormal[1]);
        deckOperator.cardDeck.Add(dataBase.cardDeckNormal[2]);
        deckOperator.cardDeck.Add(dataBase.cardDeckNormal[3]);

        deckOperator.cardDeck.Add(dataBase.cardDeckRare[0]);

        deckOperator.cardDeck.Add(dataBase.cardDeckEpic[0]);


           deckOperator.UpdateCards();


    }
}
