using System.Collections;
using System.Collections.Generic;
using UnityEditor;

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

public static class GameDeck {


    public List<Card> cardDeck = new List<Card>();


}
