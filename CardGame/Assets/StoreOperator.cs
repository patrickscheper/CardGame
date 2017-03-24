using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreOperator : MonoBehaviour {

    public int points;

    public Text pointText;

    public GameDeckDataBase dataBase;
    public GameDeckOperator deckOperator;

    public GameObject spawnStart;
    public GameObject[] spawnPoints;
    public GameObject spawnEnd;

    public List<Card> cardDeck = new List<Card>();
    public GameObject cardPrefab;

    public List<Card> currentBPack = new List<Card>();
    public List<GameObject> boosterCards = new List<GameObject>();  

    public int normalDeck;
    public int rareDeck;
    public int epicDeck;

    public bool goToSpawnPoints;
    public bool goToSpawnEnd;

    void Awake()
    {
        
        normalDeck = dataBase.cardDeckNormal.Count;
        rareDeck = dataBase.cardDeckRare.Count;
        epicDeck = dataBase.cardDeckEpic.Count;
    }



    void Update ()
    {
        pointText.text = "Current Points: " + points.ToString();

        if (goToSpawnPoints)
        {

        }



	}

    void BuyBronze()
    {
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[randomNumber(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckEpic[randomNumber(0, epicDeck)]);

        for (int i = 0; i < currentBPack.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, transform.rotation);
            newCard.transform.SetParent(transform);
            newCard.transform.position = 
            boosterCards.Add(newCard);

            newCard.transform.Find("cardImage").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("cardCategory").GetComponent<Image>().sprite = currentBPack[i].cardCategory;
            newCard.transform.Find("cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("cardAttack_title").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("cardDefence_title").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("cardTimes").GetComponent<Text>().text = (currentBPack[i].copiesInDeck).ToString();
            newCard.transform.Find("cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;



        }

        goToSpawnPoints = true;











    }


    public void UpdateCards()
    {
        if (cardDeck.Count == 0)
        {
            cardDeck = currentBPack;

            foreach (Card item in cardDeck)
            {

                if (!item.isDeck)
                {

   

                }
            }

            currentBPack = new List<Card>();
            return;

        }

        foreach (Card item in currentBPack)
        {

            foreach (Card items in cardDeck)
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

                    GameObject newCard = Instantiate(cardPrefab, transform.position, transform.rotation);

                    newCard.transform.SetParent(transform);

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

        currentBPack = new List<Card>();


    }

    public void GetBronze()
    {


        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[randomNumber(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckEpic[randomNumber(0, epicDeck)]);





        deckOperator.UpdateCards();
        //   deckOperator.currentBPack = new List<Card>();


    }

    int randomNumber(int i, int b)
    {
        return Random.Range(i, b);

    }

    IEnumerator MoveToPosition(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        Vector3 startingPos = spawnStart.transform.position;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
