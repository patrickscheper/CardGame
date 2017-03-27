using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TradingCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Card thisCard;

    public int currentCard;

    public bool isInDeck;
    public bool isInStore;

    public int value;

    public StoreOperator storeOperator;
    public DropArea dropArea;
    public GameObject sellScreen;
    public Text valueText;

    public GameObject front;
    public GameObject back;

    public bool rotate = false;

    public float t;

    public void Start()
    {

        valueText.text = thisCard.value.ToString();

    }

    private void Update()
    {


        if (rotate)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (transform.rotation.y == 1)
        {
            front.SetActive(false);
            back.SetActive(true);

        }
        else
        {
        
            front.SetActive(true);
            back.SetActive(false);
        }






        //fix rotation of new cards
        //if no gems, no booster pack

    }



    public void OnPointerClick(PointerEventData eventData)
    {
        print("CLick!");
        if (isInDeck)
        {
            if (!sellScreen.activeSelf)
                sellScreen.SetActive(true);
            else
                sellScreen.SetActive(false);

        }

        if (isInStore)
        {
            rotate = true;
            dropArea.AddBool(currentCard);
            isInStore = false;


        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Pointer Enter");
        transform.localScale = transform.localScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Pointer Exit");
        transform.localScale = new Vector3(1, 1, 1);
        sellScreen.SetActive(false);

    }

    public void SellCard()
    {
        storeOperator.gems += thisCard.value;

        transform.parent.GetComponent<GameDeckOperator>().cardDeck.Remove(thisCard);
        transform.parent.GetComponent<GameDeckOperator>().cardDeckGO.Remove(gameObject);
        Destroy(gameObject);
    }
}
