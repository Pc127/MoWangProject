using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffArray
{
    // 私有构造函数
    private BuffArray()
    {
        myBuffs = new Dictionary<string, Buff>();
    }

    // 单例类
    private static BuffArray instance = null;

    // 单例获取函数
    public static BuffArray GetInstance()
    {
        if (instance == null)
            instance = new BuffArray();

        return instance;
    }

    // 保存当前身上的buff
    public Dictionary<string ,Buff> myBuffs;


    // 加入一个buff
    public void AddBuff(string name, Buff buff)
    {
        EventManager.GetInstance().logUI.ShowText("获得了buff" + name);
        // 获取buff时
        buff.OnAcquire();

        // 加入一个buff
        if(!myBuffs.ContainsKey(name))
            myBuffs.Add(name, buff);
        else
        {
            myBuffs[name].Superposition(buff);
            Debug.Log("Buff加成" + myBuffs[name].point);
        }
    }

    // 在一轮结束后
    public void RoundOver()
    {
        foreach(var buff in myBuffs)
        {
            buff.Value.RoundOver();
        }
    }

    // 在与怪物战斗之后
    public void AfterBattle()
    {
        foreach (var buff in myBuffs)
        {
            buff.Value.AfterBattle();
        }
    }

    // 杀死一只魔物之后
    public void KillMonster()
    {
        foreach (var buff in myBuffs)
        {
            buff.Value.KillMonster();
        }
    }

    // 每行走一格时候
    public void MoveStep(int stepCount)
    {
        foreach (var buff in myBuffs)
        {
            buff.Value.MoveStep(stepCount);
        }
    }

    // 每掷出一个骰子点数时
    public void Dice(int diceIndex)
    {
        foreach (var buff in myBuffs)
        {
            buff.Value.Dice(diceIndex);
        }
    }

}
