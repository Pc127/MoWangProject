using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay
{
    // 英雄位置
    public int heroPos;

    // 移动
    public HeroMove heroMove;

    // 骰子
    public Dice dice;

    // 事件manager 采用单例形式调用
    // public EventManager eventManager;

    // 私有构造函数
    private GamePlay()
    {
        // 生成一下成员
        // EventManager.GetInstance();
    }

    // 单例类
    private static GamePlay instance = null;

    // 单例获取函数
    public static GamePlay GetInstance()
    {
        if (instance == null)
            instance = new GamePlay();

        return instance;
    }

    // 主角移动相关
    // 进行移动
    public void MakeMove(int stepCount)
    {
        heroMove.MakeMove(stepCount);
    }

    // 骰子相关
    // 显示骰子
    public void ShowMoveDice()
    {
        dice.ShowMoveDice();
    }

    // 隐藏骰子
    public void HideMoveDice()
    {
        dice.HideMoveDice();
    }

    // 棋盘事件相关
    // 利用英雄位置
    public void InvokeEvent()
    {

        EventManager.GetInstance().InvokeEvent(heroPos);
    }
}
