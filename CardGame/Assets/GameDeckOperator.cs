using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameDeckOperator : MonoBehaviour
{
    public List<Card> cardDeck = new List<Card>();
    public GameObject cardHolder;
    public GameObject cardPrefab;


    void Start()
    {
        cardDeck = new List<Card>();
    }

    void Update()
    {

    }

    public void UpdateCards()
    {
        foreach(Card item in cardDeck)
        {
            GameObject newCard = Instantiate(cardPrefab, cardHolder.transform.position, cardHolder.transform.rotation);

            newCard.transform.SetParent(cardHolder.transform);

            newCard.transform.Find("cardImage").GetComponent<Image>().sprite = item.cardImage;
            newCard.transform.Find("cardCategory").GetComponent<Image>().sprite = item.cardCategory;
            newCard.transform.Find("cardTitle").GetComponent<Text>().text = item.cardTitle;
            newCard.transform.Find("cardAttack_title").GetComponent<Text>().text = item.cardAttack.ToString();
            newCard.transform.Find("cardDefence_title").GetComponent<Text>().text = item.cardDefence.ToString();
            newCard.transform.Find("cardDescription").GetComponent<Text>().text = item.cardDesciption;




        }
    }
}
