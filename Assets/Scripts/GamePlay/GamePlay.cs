using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay
{
    public HeroMove heroMove;

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

    public void MakeMove(int stepCount)
    {
        heroMove.MakeMove(stepCount);
    }
}
