using UnityEngine;
using System.Collections;
using System;

public class Delay

{
    public static IEnumerator DelayToInvokeDo(System.Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

}