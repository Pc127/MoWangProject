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
    private Dictionary<string ,Buff> myBuffs;


    // 加入一个buff
    public void AddBuff(string name, Buff buff)
    {
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

}
