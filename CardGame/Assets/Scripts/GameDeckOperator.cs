using System.Collections.Generic;
using UnityEngine;

public class GameDeckOperator : MonoBehaviour
{
    [Header("Main Attributes")]
    [Space(2)]
    public List<Card> cardDeck = new List<Card>();
    public List<GameObject> cardDeckGO = new List<GameObject>();
    public GameObject cardHolder;
    public GameObject cardPrefab;

    public GameObject noCardsAvailable;

    private void Awake()
    {
        if (cardDeck.Count < 1)
            noCardsAvailable.SetActive(true);
    }

    void Start()
    {
        cardDeck = new List<Card>();
    }

    void Update()
    {
        if (cardDeck.Count > 1)
            noCardsAvailable.SetActive(false);
    }
}
