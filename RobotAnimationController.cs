using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FailAnim()
    {
        Scan();
    }

    internal void MoveLeft()
    {
        animator.SetBool("Left", true);
    }

    internal void MoveRight()
    {
        animator.SetBool("Right", true);
    }

    internal void CrashDown()
    {
        animator.SetBool("CrashDown", true);
    }

    internal void Idle()
    {
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("CrashDown", false);
        animator.SetBool("Scan", false);

    }

    public void Scan()
    {
        animator.SetBool("Scan", true);
    }
}
