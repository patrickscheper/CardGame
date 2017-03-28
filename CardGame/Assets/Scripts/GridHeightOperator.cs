using UnityEngine;

public class GridHeightOperator : MonoBehaviour
{
    RectTransform thisRectTransform;
    int currentRows;

    public int rowSize;
    public float heightPerRow;
    Vector2 changeVector;

    void Awake()
    {
        thisRectTransform = GetComponent<RectTransform>();
        changeVector = thisRectTransform.sizeDelta;
        InvokeRepeating("SlowUpdate", 1, 4);
    }

    void SlowUpdate()
    {
        if (transform.childCount < rowSize)
        {
            changeVector.y = (heightPerRow * (currentRows + 1));
            thisRectTransform.sizeDelta = changeVector;
            return;
        }

        currentRows = transform.childCount / rowSize;
        changeVector.y = (heightPerRow * (currentRows + 1));
        thisRectTransform.sizeDelta = changeVector;
    }
}
