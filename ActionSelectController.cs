using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSelectController : MonoBehaviour
{
    public PlayerData player;
    public GameStateController gameState;
    public UI_AvailableActions available;
    public UI_SelectedActions seleceted;

    public GameObject canvas;

    public GameObject button;
    public GameObject select;
    public GameObject selector2;

    public void InitState()
    {
        //canvas.SetActive(true);
        button.SetActive(true);
        select.SetActive(true);
        selector2.SetActive(true);

        available.Setup();
        seleceted.Setup(player.numberOfSlots);

    }

    public void DoneSelecting()
    {
        gameState.DoneSelecting(seleceted.CreateActionList());
        //canvas.SetActive(false);
        button.SetActive(false);
        select.SetActive(false);
        selector2.SetActive(true);
    }




}
