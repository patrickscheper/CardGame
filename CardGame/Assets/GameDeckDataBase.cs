using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDeckDataBase : MonoBehaviour
{
    public List<Card> cardDeckNormal = new List<Card>();
    public List<Card> cardDeckRare = new List<Card>();
    public List<Card> cardDeckEpic = new List<Card>();
}

[System.Serializable]
public class Card
{
    public bool isDeck;
    public GameObject cardObject;
    public int copiesInDeck = 0;
    public Sprite cardImage;
    public Sprite cardCategory;
    public string cardTitle;
    public string cardDesciption;
    public int cardAttack;
    public int cardDefence;
}


