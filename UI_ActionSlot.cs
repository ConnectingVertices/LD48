using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UI_ActionSlot : MonoBehaviour, IDropHandler
{
    public GameObject StoredAction;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().SetParent(this.GetComponent<RectTransform>());
            eventData.pointerDrag.GetComponent<RectTransform>().position = this.GetComponent<RectTransform>().position;

            if (StoredAction != null)
            {
                StoredAction.GetComponent<UI_DragDrop>().ImDestroyed();
                StoredAction = eventData.pointerDrag.gameObject;
                StoredAction.GetComponent<UI_DragDrop>().ParentGO(this.gameObject);
            }
            else
            {
                StoredAction = eventData.pointerDrag.gameObject;
                StoredAction.GetComponent<UI_DragDrop>().ParentGO(this.gameObject);
            }
        }
    }

    public void RemoveAction()
    {
        StoredAction = null;
    }
}
