using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{

    public GameDeckDataBase dataBase;
    public GameObject cardPrefab;
    public List<Card> currentBPack = new List<Card>();

    public GameObject myDeck;

    public GameObject doneButton;
    public GameObject StoreUI;

    public int normalDeck;
    public int rareDeck;
    public int epicDeck;

    public GameObject spawnStart;
    public GameObject[] spawnPoints;
    public GameObject spawnEnd;

    public bool goToSpawnPoints = false;
    public bool goToSpawnEnd = false;

    public GameObject[] currentCard = new GameObject[5];
    public bool[] readyCards = new bool[5];
    public List<GameObject> currentCards = new List<GameObject>();
    public float t;
    public bool b = false;

    public void Awake()
    {
        normalDeck = dataBase.cardDeckNormal.Count;
        rareDeck = dataBase.cardDeckRare.Count;
        epicDeck = dataBase.cardDeckEpic.Count;
        currentCards = new List<GameObject>();
        currentBPack = new List<Card>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        BoosterCard d = eventData.pointerDrag.GetComponent<BoosterCard>();
        if (d != null && d.cardTypes == BoosterCard.cardType.bronze)
        {
            //do soemthing bronze
            //destroy card

            GetBronze();
            Destroy(d.gameObject);
        }

        if (d != null && d.cardTypes == BoosterCard.cardType.rare)
        {
            //do soemthing bronze
            //destroy card

            GetRare();
            Destroy(d.gameObject);
        }

        if (d != null && d.cardTypes == BoosterCard.cardType.epic)
        {
            //do soemthing bronze
            //destroy card

            GetEpic();
            Destroy(d.gameObject);
        }

    }

    public void AddBool(int b)
    {
        readyCards[b] = true;

        for (int i = 0; i < readyCards.Length; i++)
        {
            if (!readyCards[i])
            { 
                return; //this "quits" the for loop, you don't need to check the rest of the items if you already found one that's not active
            }
        }

        doneButton.SetActive(true);



    }

    void Test()
    {

        for (int i = 0; 1 < 5; i++)
        {
            currentCard[i].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[i].transform.position, t);
        }
        //does not work, getting fucking crazy!
    }

    public void Update()
    {
 
        if (goToSpawnPoints)
        {
            t += 0.9f * Time.deltaTime;

          //  Test();

           currentCard[0].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[0].transform.position, t);

           currentCard[1].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[1].transform.position, t);

           currentCard[2].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[2].transform.position, t);

           currentCard[3].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[3].transform.position, t);

            currentCard[4].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[4].transform.position, t);

/*
        
            */

        }

        if (goToSpawnEnd)
        {
            t += 0.9f * Time.deltaTime;


            currentCard[0].transform.position = Vector3.Lerp(spawnPoints[0].transform.position, spawnEnd.transform.position, t);
            currentCard[0].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, t);

            currentCard[1].transform.position = Vector3.Lerp(spawnPoints[1].transform.position, spawnEnd.transform.position, t);
            currentCard[1].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, t);

            currentCard[2].transform.position = Vector3.Lerp(spawnPoints[2].transform.position, spawnEnd.transform.position, t);
            currentCard[2].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, t);

            currentCard[3].transform.position = Vector3.Lerp(spawnPoints[3].transform.position, spawnEnd.transform.position, t);
            currentCard[3].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, t);

            currentCard[4].transform.position = Vector3.Lerp(spawnPoints[4].transform.position, spawnEnd.transform.position, t);
            currentCard[4].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, t);

        }


    }

    public void SetBoolean()
    {
        doneButton.SetActive(false);

        goToSpawnPoints = false;
        t = 0;
        goToSpawnEnd = true;
        Invoke("ShowDone", 1f);




    }

    void CreateBronzeBP()
    {
        currentBPack = new List<Card>();
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[randomNumber(0, rareDeck)]);
    }

    void CreateRareBP()
    {
        currentBPack = new List<Card>();

        currentBPack.Add(dataBase.cardDeckNormal[Random.Range(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[Random.Range(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckEpic[Random.Range(0, epicDeck)]);
    }

    void CreateEpicBP()
    {
        currentBPack = new List<Card>();

        currentBPack.Add(dataBase.cardDeckNormal[Random.Range(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckEpic[Random.Range(0, epicDeck)]);
    }

    int randomNumber(int i, int b)
    {
        return Random.Range(i, b);

    }

    void ShowDone()
    {
     
        if (b)
        {

            StoreUI.SetActive(true);
            b = false;
            goToSpawnEnd = false;

            for (int i = 0; i < 5; i++)
                readyCards[i] = false;

            foreach (GameObject card in currentCard)
            {

                card.GetComponent<CanvasGroup>().alpha = 1;
                card.GetComponent<TradingCard>().storeOperator = GameObject.FindGameObjectWithTag("Store").GetComponent<StoreOperator>();

                card.transform.SetParent(myDeck.transform);
                card.GetComponent<TradingCard>().isInDeck = true;
                                myDeck.GetComponent<GameDeckOperator>().cardDeckGO.Add(card);
                myDeck.GetComponent<GameDeckOperator>().cardDeck.Add(card.GetComponent<TradingCard>().thisCard);


            }

            return;
        }



        if (!b)
        {
            StoreUI.SetActive(false);
            b = true;
        }

    }



    void GetBronze()
    {
        CreateBronzeBP();

        for (int i = 0; i < 5; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, transform.rotation);
            newCard.GetComponent<TradingCard>().dropArea = this;
            newCard.GetComponent<TradingCard>().currentCard = i;
            newCard.GetComponent<TradingCard>().thisCard = currentBPack[i];
            newCard.transform.SetParent(transform, false);
            newCard.transform.position = spawnStart.transform.position;
            newCard.transform.rotation = new Quaternion(0, 180, 0,0);
            newCard.GetComponent<TradingCard>().isInStore = true;

            newCard.transform.Find("frontCard/cardImage").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("frontCard/cardCategory").GetComponent<Image>().sprite = currentBPack[i].cardCategory;
            newCard.transform.Find("frontCard/cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("frontCard/cardAttack_title").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("frontCard/cardDefence_title").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("frontCard/cardTimes").GetComponent<Text>().text = (currentBPack[i].copiesInDeck).ToString();
            newCard.transform.Find("frontCard/cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;

            currentCard[i] = newCard;

        }

        Invoke("ShowDone", .5f);
        goToSpawnPoints = true;


        /*

                    //   newCard.transform.position = 
             //       boosterCards.Add(newCard);

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

           */
    }
    void GetRare()
    {
        CreateRareBP();

        for (int i = 0; i < 5; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, transform.rotation);
            newCard.GetComponent<TradingCard>().dropArea = this;
            newCard.GetComponent<TradingCard>().currentCard = i;
            newCard.GetComponent<TradingCard>().thisCard = currentBPack[i];
            newCard.transform.SetParent(transform, false);
            newCard.transform.position = spawnStart.transform.position;
            newCard.transform.rotation = new Quaternion(0, 180, 0, 0);
            newCard.GetComponent<TradingCard>().isInStore = true;

            newCard.transform.Find("frontCard/cardImage").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("frontCard/cardCategory").GetComponent<Image>().sprite = currentBPack[i].cardCategory;
            newCard.transform.Find("frontCard/cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("frontCard/cardAttack_title").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("frontCard/cardDefence_title").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("frontCard/cardTimes").GetComponent<Text>().text = (currentBPack[i].copiesInDeck).ToString();
            newCard.transform.Find("frontCard/cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;

            currentCard[i] = newCard;

        }

        Invoke("ShowDone", .5f);
        goToSpawnPoints = true;


        /*

                    //   newCard.transform.position = 
             //       boosterCards.Add(newCard);

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

           */
    }
    void GetEpic()
    {
        CreateEpicBP();

        for (int i = 0; i < 5; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, transform.rotation);
            newCard.GetComponent<TradingCard>().dropArea = this;
            newCard.GetComponent<TradingCard>().currentCard = i;
            newCard.GetComponent<TradingCard>().thisCard = currentBPack[i];
            newCard.transform.SetParent(transform, false);
            newCard.transform.position = spawnStart.transform.position;
            newCard.transform.rotation = new Quaternion(0, 180, 0, 0);
            newCard.GetComponent<TradingCard>().isInStore = true;

            newCard.transform.Find("frontCard/cardImage").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("frontCard/cardCategory").GetComponent<Image>().sprite = currentBPack[i].cardCategory;
            newCard.transform.Find("frontCard/cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("frontCard/cardAttack_title").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("frontCard/cardDefence_title").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("frontCard/cardTimes").GetComponent<Text>().text = (currentBPack[i].copiesInDeck).ToString();
            newCard.transform.Find("frontCard/cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;

            currentCard[i] = newCard;

        }

        Invoke("ShowDone", .5f);
        goToSpawnPoints = true;


        /*

                    //   newCard.transform.position = 
             //       boosterCards.Add(newCard);

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

           */
    }


}
