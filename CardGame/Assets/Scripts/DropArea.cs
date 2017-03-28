using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    [Header("Main Attributes")]
    [Space(2)]
    public GameDeckDataBase dataBase;
    public GameObject cardPrefab;
    public List<Card> currentBPack = new List<Card>();

    public GameObject myDeck;

    public GameObject doneButton;
    public GameObject StoreUI;

    private int normalDeck;
    private int rareDeck;
    private int epicDeck;

    public GameObject spawnStart;
    public GameObject[] spawnPoints;
    public GameObject spawnEnd;

    private bool goToSpawnPoints = false;
    private bool goToSpawnEnd = false;

    [HideInInspector]
    public GameObject[] currentCard = new GameObject[5];
    [HideInInspector]
    public bool[] readyCards = new bool[5];
    [HideInInspector]
    public List<GameObject> currentCards = new List<GameObject>();
    private float t;
    private bool b = false;

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
            GetBronze();
            Destroy(d.gameObject);
        }

        if (d != null && d.cardTypes == BoosterCard.cardType.silver)
        {
            GetRare();
            Destroy(d.gameObject);
        }

        if (d != null && d.cardTypes == BoosterCard.cardType.gold)
        {
            GetEpic();
            Destroy(d.gameObject);
        }
    }

    public void AddBool(int b)
    {
        readyCards[b] = true;

        for (int i = 0; i < readyCards.Length; i++)
            if (!readyCards[i])
                return;

        doneButton.SetActive(true);
    }

    public void Update()
    {
        if (goToSpawnPoints)
        {
            t += 0.9f * Time.deltaTime;

            currentCard[0].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[0].transform.position, t);

            currentCard[1].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[1].transform.position, t);

            currentCard[2].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[2].transform.position, t);

            currentCard[3].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[3].transform.position, t);

            currentCard[4].transform.position = Vector3.Lerp(spawnStart.transform.position, spawnPoints[4].transform.position, t);
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
        currentBPack = new List<Card>();
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[randomNumber(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[randomNumber(0, rareDeck)]);

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

            newCard.transform.Find("frontCard/image_cardAvatar").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("frontCard/text_cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("frontCard/text_cardAttack").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("frontCard/text_cardDefence").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("frontCard/text_cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;

            currentCard[i] = newCard;

            if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.normal)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryNormal;

            else if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.rare)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryRare;

            else if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.epic)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryEpic;
        }

        Invoke("ShowDone", .5f);
        goToSpawnPoints = true;
    }

    void GetRare()
    {
        currentBPack = new List<Card>();
        currentBPack.Add(dataBase.cardDeckNormal[Random.Range(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckNormal[Random.Range(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckEpic[Random.Range(0, epicDeck)]);

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


            newCard.transform.Find("frontCard/image_cardAvatar").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("frontCard/text_cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("frontCard/text_cardAttack").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("frontCard/text_cardDefence").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("frontCard/text_cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;

            currentCard[i] = newCard;
            if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.normal)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryNormal;

            else if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.rare)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryRare;

            else if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.epic)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryEpic;
        }

        Invoke("ShowDone", .5f);
        goToSpawnPoints = true;
    }

    void GetEpic()
    {
        currentBPack = new List<Card>();
        currentBPack.Add(dataBase.cardDeckNormal[Random.Range(0, normalDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckRare[Random.Range(0, rareDeck)]);
        currentBPack.Add(dataBase.cardDeckEpic[Random.Range(0, epicDeck)]);

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

            newCard.transform.Find("frontCard/image_cardAvatar").GetComponent<Image>().sprite = currentBPack[i].cardImage;
            newCard.transform.Find("frontCard/text_cardTitle").GetComponent<Text>().text = currentBPack[i].cardTitle;
            newCard.transform.Find("frontCard/text_cardAttack").GetComponent<Text>().text = currentBPack[i].cardAttack.ToString();
            newCard.transform.Find("frontCard/text_cardDefence").GetComponent<Text>().text = currentBPack[i].cardDefence.ToString();
            newCard.transform.Find("frontCard/text_cardDescription").GetComponent<Text>().text = currentBPack[i].cardDesciption;
            currentBPack[i].isDeck = true;
            currentBPack[i].cardObject = newCard;

            currentCard[i] = newCard;
            if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.normal)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryNormal;

            else if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.rare)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryRare;

            else if (newCard.GetComponent<TradingCard>().thisCard.cardTypes == Card.cardType.epic)
                newCard.transform.Find("frontCard/image_cardType").GetComponent<Image>().sprite = dataBase.categoryEpic;
        }

        Invoke("ShowDone", .5f);
        goToSpawnPoints = true;
    }


}
