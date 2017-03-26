using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreOperator : MonoBehaviour {

    public int gems;

    public Text currentGemsText;

    public GameObject boosterpackPanel;

    public GameObject bronzepack;
    public GameObject rarepack;
    public GameObject epicpack;


    void Update ()
    {
        currentGemsText.text = "Current Gems: " + gems.ToString();



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

    public void BuyRare()
    {if (gems >= 75)
        {
            gems -= 75;

            GameObject newCard = Instantiate(rarepack, boosterpackPanel.transform.position, boosterpackPanel.transform.rotation);
            newCard.transform.SetParent(boosterpackPanel.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.GetComponent<BoosterCard>().cardTypes = BoosterCard.cardType.rare;
        }

    }

    public void BuyEpic()
    {if (gems >= 100)
        {
            gems -= 100;

            GameObject newCard = Instantiate(epicpack, boosterpackPanel.transform.position, boosterpackPanel.transform.rotation);
            newCard.transform.SetParent(boosterpackPanel.transform);
            newCard.transform.localScale = new Vector3(1, 1, 1);
            newCard.GetComponent<BoosterCard>().cardTypes = BoosterCard.cardType.epic;
        }

    }
}
