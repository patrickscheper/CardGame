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
public struct Card
{
    public Sprite cardImage;
    public Sprite cardCategory;
    public string cardTitle;
    public string cardDesciption;
    public int cardAttack;
    public int cardDefence;
}


