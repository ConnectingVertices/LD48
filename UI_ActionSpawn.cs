using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_ActionSpawn : MonoBehaviour
{
    public GameObject spawnedAction;
    public Text text;

    private int number;

    private Queue<GameObject> allActions = new Queue<GameObject> { };


    internal void OneDestroyed()
    {
        GameObject temp = Instantiate(spawnedAction, transform);
        temp.SetActive(true);
        allActions.Enqueue(temp);
    }

    internal void Setup(int action)
    {
        while(allActions.Count > 0)
        {
            Destroy(allActions.Dequeue());
        }

        number = action;
        text.text = action.ToString();

        for (int i = 0; i < action; i++)
        {
            GameObject temp = Instantiate(spawnedAction, transform);
            temp.SetActive(true);
            allActions.Enqueue(temp);
        }
    }
}
