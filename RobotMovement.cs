using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 homePosition = new Vector3(0,14,0);

    public PlayerData player;
    public RobotAnimationController robotAnimator;

    private float timeElapsed;
    private bool startMove;

    // Start is called before the first frame update
    void Start()
    {
        startMove = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startMove)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / player.Speed);
            timeElapsed += Time.deltaTime;
        }

        
    }

    public void ReturnHome()
    {
        startPosition = transform.position;
        endPosition = homePosition;
        timeElapsed = 0;
        startMove = true;

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            startMove = false;
        }));

    }

    public void FirstMove()
    {
        startPosition = homePosition;
        endPosition = new Vector3(0, 0, 0);
        timeElapsed = 0;
        startMove = true;

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            startMove = false;
        }));


    }

    public void MoveDown()
    {
        startPosition = transform.position;
        endPosition = transform.position + Vector3.down * 10;
        timeElapsed = 0;
        startMove = true;

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            startMove = false;
        }));


    }

    public void MoveLeft()
    {
        startPosition = transform.position;
        endPosition = transform.position + Vector3.right * 14;
        timeElapsed = 0;
        startMove = true;

        robotAnimator.MoveLeft();

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            robotAnimator.Idle();
            startMove = false;
        }));


    }

    internal void Scan()
    {
        robotAnimator.Scan();

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            robotAnimator.Idle();

        }));
    }

    public void MoveRight()
    {
        startPosition = transform.position;
        endPosition = transform.position + Vector3.left * 14;
        timeElapsed = 0;
        startMove = true;

        robotAnimator.MoveRight();

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            robotAnimator.Idle();
            startMove = false;
        }));
    }

    public void CrashDown()
    {
        robotAnimator.CrashDown();

        StartCoroutine(Utils.WaitABit(player.Speed + 0.5f, () =>
        {
            robotAnimator.Idle();

        }));
    }

    public void CrashLeft()
    {
        robotAnimator.Scan();

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            robotAnimator.Idle();

        }));
    }

    public void CrashRight()
    {
        robotAnimator.Scan();

        StartCoroutine(Utils.WaitABit(player.Speed + Time.deltaTime, () =>
        {
            robotAnimator.Idle();

        }));

    }






}
