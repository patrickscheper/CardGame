using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDeckDataBase : MonoBehaviour
{
    public List<Card> cardDeckNormal = new List<Card>();
    public List<Card> cardDeckRare = new List<Card>();
    public List<Card> cardDeckEpic = new List<Card>();

    public Sprite categoryNormal;
    public Sprite categoryRare;
    public Sprite categoryEpic;
   
    public void Awake()
    {
        foreach(Card card in cardDeckNormal)
        {

                card.value += Random.Range(3, 6);
       
        }

        foreach (Card card in cardDeckRare)
        {

            card.value += Random.Range(6, 14);

        }

        foreach (Card card in cardDeckEpic)
        {

            card.value += Random.Range(14, 25);

        }

    }



}


[System.Serializable]
public class Card
{
    public enum cardType { normal, rare, epic };
    public cardType cardTypes;

    public bool isDeck;
    public int value;
    public GameObject cardObject;
    public int copiesInDeck = 0;
    public Sprite cardImage;
    public Sprite cardCategory;
    public string cardTitle;
    public string cardDesciption;
    public int cardAttack;
    public int cardDefence;
}


