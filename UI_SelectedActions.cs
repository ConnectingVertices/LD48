using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SelectedActions : MonoBehaviour
{
    public GameObject[] ActionSlots;

    public void Setup(int slots)
    {
        if (slots < 8)
        {
            ActionSlots[7].SetActive(false);
        }
        else
            ActionSlots[7].SetActive(true);

        if (slots < 7)
        {
            ActionSlots[6].SetActive(false);
        }
        else
            ActionSlots[6].SetActive(true);
    }

    public Queue<IDroidAction> CreateActionList()
    {
        Queue<IDroidAction> actionList = new Queue<IDroidAction>();

        foreach (GameObject actionSlot in ActionSlots)
        {
            if (actionSlot != null)
            {
                if (actionSlot.GetComponent<UI_ActionSlot>() != null)
                {
                    if (actionSlot.GetComponent<UI_ActionSlot>().StoredAction != null)
                    {
                        actionList.Enqueue(actionSlot.GetComponent<UI_ActionSlot>().StoredAction.GetComponent<IDroidAction>());
                    }
                }
            }
        }
        return actionList;
    }

    public void PrintList()
    {
        Queue<IDroidAction> printQueue = CreateActionList();

        while (printQueue.Count > 0)
        {
            Debug.Log(printQueue.Dequeue());

        }

    }





}
