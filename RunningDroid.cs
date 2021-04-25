using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDroid : MonoBehaviour
{

    public GameStateController GameStateController;
    public RobotAnimationController robotAnim;
    public RobotMovement movement;
    public Droid droid;
    public PlayerData player;

    public GameObject BadSound;
    public GameObject GoodSound;

    Queue<IDroidAction> actionList;

    //private bool actionDone = false;


    /* public void Update()
     {
         if (actionDone && GameStateController.GameState == GameStateController.GameStates.running)
         {
             actionDone = false;
             DoActions();
         }
     }*/

    public void InitState(Queue<IDroidAction> list)
    {

        actionList = list;
 //       actionDone = false;

        movement.FirstMove();

        StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
        {

            DoActions();

        }));

    }

    public void RobotFail()
    {
        robotAnim.FailAnim();

        BadSound.SetActive(true);

        StartCoroutine(Utils.WaitABit(1.5f, () =>
        {
            BadSound.SetActive(false);

        }));

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            robotAnim.Idle();
        }));
    }

    public void DoActions()
    {
        if (GameStateController.GameState != GameStateController.GameStates.running)
            return;


        if (actionList.Count < 1)
        {
            GoodSound.SetActive(true);

            StartCoroutine(Utils.WaitABit(1.5f, () =>
            {
                GoodSound.SetActive(false);

            }));

            ReturnHome();

            return;
        }

        IDroidAction action = actionList.Dequeue();

        if (action.GetType() == typeof(ActionDown))
        {
            if (droid.CanGoDown)
            {
                movement.MoveDown();

                StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
                {
                    DoActions();
                }));

            }
            else
            {
                movement.CrashDown();

                BadSound.SetActive(true);

                StartCoroutine(Utils.WaitABit(1.5f, () =>
                {
                    BadSound.SetActive(false);

                }));



                ReturnHome();
            }


        }

        if (action.GetType() == typeof(ActionSearch))
        {
            movement.Scan();

            if (player.ExploredRooms.Contains(player.CurrentRoom))
            {
                StartCoroutine(Utils.WaitABit(player.Speed - 0.5f, () =>
                {
                    //ErrorMusic
                }));

            }
            else
            {
                StartCoroutine(Utils.WaitABit(player.Speed - 0.25f, () =>
                {
                    //Happy Music
                    //player.CurrentRoom.Treasure.SetActive(true);
                    player.ExploredRooms.Add(player.CurrentRoom);
                    player.CurrentRoom.IsExplored();
                }));

            }

            StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
            {
                DoActions();
            }));

        }

        if (action.GetType() == typeof(ActionLeft))
        {
            MoveLeft();
        }

        if (action.GetType() == typeof(ActionRight))
        {
            MoveRight();
        }

        if (action.GetType() == typeof(ActionDoubleRight))
        {
            if (droid.CanGoRight)
            {
                movement.MoveRight();

                StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
                {
                    MoveRight();
                }));
            }
            else
            {
                movement.CrashRight();
                BadSound.SetActive(true);

                StartCoroutine(Utils.WaitABit(1.5f, () =>
                {
                    BadSound.SetActive(false);

                }));
                ReturnHome();
            }
        }

        if (action.GetType() == typeof(ActionDoubleLeft))
        {
            if (droid.CanGoLeft)
            {
                movement.MoveLeft();

                StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
                {
                    MoveLeft();
                }));
            }
            else
            {
                movement.CrashLeft();
                BadSound.SetActive(true);

                StartCoroutine(Utils.WaitABit(1.5f, () =>
                {
                    BadSound.SetActive(false);

                }));
                ReturnHome();
            }
        }
    }

    private void MoveLeft()
    {
        if (droid.CanGoLeft)
        {
            movement.MoveLeft();

            StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
            {
                DoActions();
            }));
        }
        else
        {
            movement.CrashLeft();
            BadSound.SetActive(true);

            StartCoroutine(Utils.WaitABit(1.5f, () =>
            {
                BadSound.SetActive(false);

            }));
            ReturnHome();
        }


    }

    private void ReturnHome()
    {
        StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
        {
            GameStateController.ActionsComplete();
            movement.ReturnHome();
            droid.Renderer.SetActive(false);
            return;
        }));

        StartCoroutine(Utils.WaitABit(player.Speed * 2 + 0.5f, () =>
        {
            droid.Renderer.SetActive(true);
        }));
    }

    private void MoveRight()
    {
        if (droid.CanGoRight)
        {
            movement.MoveRight();

            StartCoroutine(Utils.WaitABit(player.Speed + 0.25f, () =>
            {
                DoActions();
            }));
        }
        else
        {
            movement.CrashRight();
            BadSound.SetActive(true);

            StartCoroutine(Utils.WaitABit(1.5f, () =>
            {
                BadSound.SetActive(false);

            }));
            ReturnHome();
        }
    }
}
