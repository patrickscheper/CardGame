using UnityEngine;
using UnityEngine.UI;

public class StoreOperator : MonoBehaviour
{
    [Header("Main Attributes")]
    [Space(2)]
    public int gems;
    public Text currentGemsText;

    public GameObject boosterpackPanel;

    public GameObject bronzepack;
    public GameObject rarepack;
    public GameObject epicpack;

    public bool showInfo;
    public GameObject infoScreen;
    public MovieTexture infoVideo;


    void Update()
    {
        currentGemsText.text = gems.ToString();
    }

    public void ShowInfo()
    {
        infoScreen.SetActive(true);
        infoVideo.Play();
        Invoke("StopVideo", infoVideo.duration);
    }

    void StopVideo()
    {
        infoVideo.Stop();
        infoScreen.SetActive(false);
    }

    public void BuyBronze()
    {
        if (gems >= 50)
        {
            gems -= 50;

            GameObject newCard = Instantiate(bronzepack, boosterpackPanel.transform.position, boosterpackPanel.transform.rotation);
            newCard.transform.SetParent(boosterpackPanel.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.GetComponent<BoosterCard>().cardTypes = BoosterCard.cardType.bronze;
        }
    }

    public void BuySilver()
    {
        if (gems >= 75)
        {
            gems -= 75;

            GameObject newCard = Instantiate(rarepack, boosterpackPanel.transform.position, boosterpackPanel.transform.rotation);
            newCard.transform.SetParent(boosterpackPanel.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.GetComponent<BoosterCard>().cardTypes = BoosterCard.cardType.silver;
        }
    }

    public void BuyGold()
    {
        if (gems >= 100)
        {
            gems -= 100;

            GameObject newCard = Instantiate(epicpack, boosterpackPanel.transform.position, boosterpackPanel.transform.rotation);
            newCard.transform.SetParent(boosterpackPanel.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.GetComponent<BoosterCard>().cardTypes = BoosterCard.cardType.gold;
        }
    }
}
