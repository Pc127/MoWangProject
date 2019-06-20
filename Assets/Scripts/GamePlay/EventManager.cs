using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    // 私有构造
    private EventManager()
    {
        NewSceneUpdate();
       // GamePlay.GetInstance().eventManager = this;
    }

    public void NewSceneUpdate()
    {
        // 获取当前的buffs
        currentBuffs = GamePersist.GetInstance().GetBuffEvents();
    }

    // 单例类
    private static EventManager instance = null;

    // 单例获取函数
    public static EventManager GetInstance()
    {
        if (instance == null)
            instance = new EventManager();

        return instance;
    }

    // 当前关卡的buff信息
    private BuffEvents currentBuffs;

    // buff相关的ui逻辑
    public BuffUI buffUI;

    public void InvokeEvent(int heroPos)
    {
        // 先检查怪物

        // 触发buff事件
        buffUI.GetBuffEvent(currentBuffs.myBuffs[heroPos]);

    }
}
