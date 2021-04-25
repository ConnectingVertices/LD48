using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public bool CanGoDown = false;
    public bool CanGoRight = true;
    public bool CanGoLeft = true;

    public int RoomID;

    public GameObject Light1;
    public GameObject Light2;
    //public GameObject Light3;

    //public GameObject Treasure;

    void Start()
    {
        Light1.SetActive(false);
        Light2.SetActive(false);
   //     Light3.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Droid>().playerData.GameState.GameState != GameStateController.GameStates.running)
            return;

        Droid droid = other.GetComponent<Droid>();
        bool hasExploderd = droid.SetRoom(this);

        droid.CanGoDown = CanGoDown;
        droid.CanGoLeft = CanGoLeft;
        droid.CanGoRight = CanGoRight;

        Light1.SetActive(true);
        Light2.SetActive(true);
   //     Light1.SetActive(hasExploderd);
    //    Light2.SetActive(hasExploderd);
    //    Light3.SetActive(!hasExploderd);


    }

    private void OnTriggerExit(Collider other)
    {
        Light1.SetActive(false);
        Light2.SetActive(false);
    //    Light3.SetActive(false);
    }

    public void IsExplored()
    {
        Light1.SetActive(true);
        Light2.SetActive(true);
    //    Light3.SetActive(false);
    }



}
