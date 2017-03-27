using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoosterCard : MonoBehaviour, IBeginDragHandler ,IDragHandler, IEndDragHandler{

    public Transform parentToReturnTo = null;
    CanvasGroup canvasGroup;
    public enum cardType{ bronze, silver, gold };
    public cardType cardTypes;
    

    public void Start()
    {
        parentToReturnTo = transform.parent;
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(parentToReturnTo.parent);
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);

        // canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
          //  eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentToReturnTo);
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);

        canvasGroup.blocksRaycasts = true;

    }



}
