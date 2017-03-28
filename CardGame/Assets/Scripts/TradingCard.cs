using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TradingCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [Header("Main Attributes")]
    [Space(2)]
    public Card thisCard;
    private int value;

    [HideInInspector]
    public int currentCard;
    [HideInInspector]
    public bool isInDeck;
    [HideInInspector]
    public bool isInStore;

    [Header("Current Object Properties")]
    [Space(2)]
    public GameObject front;
    public GameObject back;

    [Space(2)]
    public GameObject sellScreen;
    public Text valueText;
    public GameObject sellButton;
    public GameObject sellMenu;

    [HideInInspector]
    public DropArea dropArea;
    [HideInInspector]
    public StoreOperator storeOperator;

    private bool rotate = false;
    private float t;

    public void Start()
    {
        valueText.text = thisCard.value.ToString();
    }

    private void Update()
    {
        if (rotate)
            transform.rotation = new Quaternion(0, 0, 0, 0);

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
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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
        transform.localScale = transform.localScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);

        HideSellMenu();
    }

    public void HideSellMenu()
    {
        if (sellMenu.activeInHierarchy)
            sellMenu.SetActive(false);

        sellButton.SetActive(true);
        sellScreen.SetActive(false);
    }

    public void ShowSellMenu()
    {
        sellButton.SetActive(false);
        sellMenu.SetActive(true);
    }

    public void SellCard()
    {
        storeOperator.gems += thisCard.value;

        transform.parent.GetComponent<GameDeckOperator>().cardDeck.Remove(thisCard);
        transform.parent.GetComponent<GameDeckOperator>().cardDeckGO.Remove(gameObject);
        Destroy(gameObject);
    }
}
