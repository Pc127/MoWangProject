using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoint
{
    // 私有构造
    private ActionPoint()
    {
        point = 17;
    }
    // 单例类
    private static ActionPoint instance = null;

    // 单例获取函数
    public static ActionPoint GetInstance()
    {
        if (instance == null)
            instance = new ActionPoint();

        return instance;
    }

    public int point;
}
