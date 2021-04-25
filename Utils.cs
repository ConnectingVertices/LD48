using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    /*
        StartCoroutine(Utils.WaitABit(1f, () => 
        {
        
        }));
    */

    public static IEnumerator WaitABit(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);

        action();
    }







}
