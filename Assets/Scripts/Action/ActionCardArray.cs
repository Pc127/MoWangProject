using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCardArray
{
    // 私有构造函数
    private ActionCardArray()
    {
        myActions = new Dictionary<string, Action>();
    }

    // 单例类
    private static ActionCardArray instance = null;

    // 单例获取函数
    public static ActionCardArray GetInstance()
    {
        if (instance == null)
            instance = new ActionCardArray();

        return instance;
    }

    // 保存当前身上的Action
    public Dictionary<string ,Action> myActions;

    // 加入一张行动卡片
    public void AddActionCard(string name, Action ac)
    {
        // 存在的话增加数量
        if (myActions.ContainsKey(name))
        {
            myActions[name].count++;
            myActions[name].activeCount++;
        }
        else
        {
            ac.count = 1;
            ac.activeCount = 1;
            // 加入一张行动卡
            Debug.Log("加入一张行动卡");
            myActions.Add(name, ac);
        }
    }

    // 使用一张行动卡片 使其进入冷却
    public void UseActionCard(string name)
    {
        // 使其进入冷却
        myActions[name].activeCount--;
    }

}
