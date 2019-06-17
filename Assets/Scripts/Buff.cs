using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    // 在获得时候
    public virtual void OnAcquire()
    {

    }

    // 在失去时候
    public virtual void OnDestroy()
    {

    }

    // 在一轮结束后
    public virtual void RoundOver()
    {

    }

    // 在与怪物战斗之后
    public virtual void AfterBattle()
    {

    }

    // 杀死一只魔物之后
    public virtual void KillMonster()
    {

    }

    // 每行走一格时候
    public virtual void MoveStep(int stepCount)
    {

    }

    // 每掷出一个骰子点数时
    public virtual void Dice(int diceIndex)
    {

    }

}
