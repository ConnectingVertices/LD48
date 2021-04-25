using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameStateController controller;
    public RunningDroid droid;
    public GameObject sound;

    public GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        controller.GameState = GameStateController.GameStates.paused;

        droid.StopAllCoroutines();

        sound.SetActive(true);

        StartCoroutine(Utils.WaitABit(4f, () =>
        {

            panel.SetActive(true);


        }));
    }
}
