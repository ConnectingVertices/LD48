using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public enum GameStates {paused, selecting, running}

    public GameStates GameState;
    public ActionSelectController actionSelect;
    public RunningDroid runningDroid;

    public PlayerData playerData;

    
    void Start()
    {

        GameState = GameStates.paused;



    }

    public void StartGame()
    {

        GameState = GameStates.selecting;
        actionSelect.InitState();

    }




    public void DoneSelecting(Queue<IDroidAction> actionList)
    {
        if (actionList.Count > 0)
        {

            GameState = GameStates.running;
            StartCoroutine(Utils.WaitABit(0.5f, () =>
            {   
                runningDroid.InitState(actionList);
            }));
        }
        else
        {
            GameState = GameStates.paused;

            runningDroid.RobotFail();

            StartCoroutine(Utils.WaitABit(0.5f, () =>
            {
                //Play failmusic
            }));

            StartCoroutine(Utils.WaitABit(playerData.Speed, () =>
            {
                GameState = GameStates.selecting;
                actionSelect.InitState();
            }));

        }
    }

    internal void ActionsComplete()
    {
        GameState = GameStates.paused;

        StartCoroutine(Utils.WaitABit(playerData.Speed, () =>
        {
            GameState = GameStates.selecting;
            actionSelect.InitState();
        }));
    }
}
