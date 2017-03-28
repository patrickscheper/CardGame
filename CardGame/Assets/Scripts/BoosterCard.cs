using UnityEngine;
using UnityEngine.EventSystems;

public class BoosterCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Main Attributes")]
    [Space(2)]
    public cardType cardTypes;
    public enum cardType { bronze, silver, gold };
 

    private Transform parentToReturnTo = null;
    private CanvasGroup canvasGroup;

    public void Start()
    {
        parentToReturnTo = transform.parent;
       canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(parentToReturnTo.parent.parent);
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentToReturnTo);
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);

        canvasGroup.blocksRaycasts = true;
    }
}
