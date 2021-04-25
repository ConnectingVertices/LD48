using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid : MonoBehaviour
{

    public PlayerData playerData;

    public bool CanGoDown = false;
    public bool CanGoRight = true;
    public bool CanGoLeft = true;

    public GameObject Renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetRoom(Room room)
    {
        playerData.CurrentRoom = room;

        return playerData.ExploredRooms.Contains(room);

    }


}
