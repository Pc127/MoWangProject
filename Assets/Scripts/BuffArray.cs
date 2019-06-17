using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffArray
{
    // 私有构造函数
    private BuffArray()
    {
        myBuffs = new List<Buff>();
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
    private List<Buff> myBuffs;

}
