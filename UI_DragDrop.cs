using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UI_DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject parentGO;
    public Canvas canvas;
    public GameStateController controller;

    private CanvasGroup canvasGroup;
    private RectTransform trans;
    private UI_ActionSpawn spawner;

    void Awake()
    {
        trans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        spawner = trans.GetComponentInParent<UI_ActionSpawn>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (controller.GameState == GameStateController.GameStates.selecting)
        {
            canvasGroup.blocksRaycasts = false;

            if (parentGO != null)
            {
                parentGO?.GetComponent<UI_ActionSlot>().RemoveAction();
                parentGO = null;
            }
            trans.SetParent(canvas.transform);
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (controller.GameState == GameStateController.GameStates.selecting)
        {
            trans.anchoredPosition += eventData.delta * canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void ParentGO(GameObject gameObject)
    {
        parentGO = gameObject;
    }

    public void ImDestroyed()
    {
        spawner.OneDestroyed();
        Destroy(this.gameObject);
    }

}
