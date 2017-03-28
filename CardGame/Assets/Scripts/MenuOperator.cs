using UnityEngine;

public class MenuOperator : MonoBehaviour
{
    public GameObject myDeckCanvas;
    public GameObject StoreCanvas;

    private void Awake()
    {
        myDeckCanvas.SetActive(true);
        StoreCanvas.SetActive(false);
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
