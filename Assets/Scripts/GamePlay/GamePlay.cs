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

    // 主角死亡
    public YouDie die;

    // 怪物加载
    public MonsterLoad monsterLoad;

    // 私有构造函数
    private GamePlay()
    {
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

    // 不触发行动事件的移动
    public void MakeMoveWithoutAction(int step)
    {
        heroMove.MakeMoveWithoutAction(step);
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
}
