using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOperator : MonoBehaviour
{

    public GameObject myDeckCanvas;
    public GameObject StoreCanvas;





    // Use this for initialization



    void Update()
    {

    }

    public void SwitchCanvas(bool i)
    {
        if (i)
        {
            myDeckCanvas.SetActive(i);
            StoreCanvas.SetActive(!i);

            return;
        }
        myDeckCanvas.SetActive(i);
        StoreCanvas.SetActive(!i);

    }



}
