using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameDeckOperator : MonoBehaviour
{
    public List<Card> cardDeck = new List<Card>();
    public List<Card> boosterPack = new List<Card>();
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
        if(cardDeck.Count == 0)
        {
            cardDeck = boosterPack;

            foreach (Card item in cardDeck)
            {

                if (!item.isDeck)
                {

                    GameObject newCard = Instantiate(cardPrefab, cardHolder.transform.position, cardHolder.transform.rotation);

                    newCard.transform.SetParent(cardHolder.transform);

                    newCard.transform.Find("cardImage").GetComponent<Image>().sprite = item.cardImage;
                    newCard.transform.Find("cardCategory").GetComponent<Image>().sprite = item.cardCategory;
                    newCard.transform.Find("cardTitle").GetComponent<Text>().text = item.cardTitle;
                    newCard.transform.Find("cardAttack_title").GetComponent<Text>().text = item.cardAttack.ToString();
                    newCard.transform.Find("cardDefence_title").GetComponent<Text>().text = item.cardDefence.ToString();
                    newCard.transform.Find("cardTimes").GetComponent<Text>().text = (item.copiesInDeck).ToString();
                    newCard.transform.Find("cardDescription").GetComponent<Text>().text = item.cardDesciption;
                    item.isDeck = true;
                    item.cardObject = newCard;

                }
            }

            boosterPack = new List<Card>();
            return;

        }

        foreach (Card item in boosterPack)
        {

            foreach(Card items in cardDeck)
            {
                

                if (item.cardTitle == items.cardTitle)
                {
                    print("This card is the same!");

                    items.copiesInDeck += 1;
                    items.cardObject.transform.Find("cardTimes").GetComponent<Text>().text = (item.copiesInDeck).ToString();
      
                }
                if (item.cardTitle != items.cardTitle)
                {
                    print("There's a new card: " + item.cardTitle);

                    GameObject newCard = Instantiate(cardPrefab, cardHolder.transform.position, cardHolder.transform.rotation);

                    newCard.transform.SetParent(cardHolder.transform);

                    newCard.transform.Find("cardImage").GetComponent<Image>().sprite = item.cardImage;
                    newCard.transform.Find("cardCategory").GetComponent<Image>().sprite = item.cardCategory;
                    newCard.transform.Find("cardTitle").GetComponent<Text>().text = item.cardTitle;
                    newCard.transform.Find("cardAttack_title").GetComponent<Text>().text = item.cardAttack.ToString();
                    newCard.transform.Find("cardDefence_title").GetComponent<Text>().text = item.cardDefence.ToString();
                    newCard.transform.Find("cardTimes").GetComponent<Text>().text = (item.copiesInDeck).ToString();
                    newCard.transform.Find("cardDescription").GetComponent<Text>().text = item.cardDesciption;
                    item.isDeck = true;
                    item.cardObject = newCard;

                    //add new card
                }

            }

        }

        boosterPack = new List<Card>();


    }
}
