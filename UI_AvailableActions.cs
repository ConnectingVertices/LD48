using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_AvailableActions : MonoBehaviour
{
    public PlayerData player;

    public UI_ActionSpawn actionScan;
    public UI_ActionSpawn actionLeft;
    public UI_ActionSpawn actionRight;
    public UI_ActionSpawn actionDown;
    public UI_ActionSpawn actionDLeft;
    public UI_ActionSpawn actionDRight;



    public void Setup()
    {
        if (player.ActionScan > 0)
        {
            actionScan.gameObject.SetActive(true);
            actionScan.Setup(player.ActionScan);
        }
        else
            actionScan.gameObject.SetActive(false);

        if (player.ActionLeft > 0)
        {
            actionLeft.gameObject.SetActive(true);
            actionLeft.Setup(player.ActionLeft);
        }
        else
            actionLeft.gameObject.SetActive(false);

        if (player.ActionRight > 0)
        {
            actionRight.gameObject.SetActive(true);
            actionRight.Setup(player.ActionRight);
        }
        else
            actionRight.gameObject.SetActive(false);

        if (player.ActionDown > 0)
        {
            actionDown.gameObject.SetActive(true);
            actionDown.Setup(player.ActionDown);
        }
        else
            actionDown.gameObject.SetActive(false);

        if (player.ActionDoubleLeft > 0)
        {
            actionDLeft.gameObject.SetActive(true);
            actionDLeft.Setup(player.ActionDoubleLeft);
        }
        else
            actionDLeft.gameObject.SetActive(false);

        if (player.ActionDoubleRight > 0)
        {
            actionDRight.gameObject.SetActive(true);
            actionDRight.Setup(player.ActionDoubleRight);
        }
        else
            actionDRight.gameObject.SetActive(false);

    }

}
