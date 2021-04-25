using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public int numberOfSlots;

    public int ActionLeft = 0;
    public int ActionRight = 0;
    public int ActionDoubleLeft = 0;
    public int ActionDoubleRight = 0;
    public int ActionScan = 2;
    public int ActionDown = 0;

    public float Speed = 1.5f;

    public Room CurrentRoom;
    public List<Room> ExploredRooms;

    public GameStateController GameState;



    public void SpeedChange(bool vool)
    {
        if (vool)
        {
            Speed = 0.75f;

        }
        else
        {
            Speed = 1.5f;

        }



    }







}
