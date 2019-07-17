using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory
{
    // 私有构造函数
    private MonsterFactory()
    {
        myMonsters = new List<Monster>();

        // 0-10怪物
        myMonsters.Add(new BlackSheep());
        myMonsters.Add(new SneakMan());
        myMonsters.Add(new ArmBrokenKnight());
        myMonsters.Add(new OctopusMan());
        myMonsters.Add(new BleakGhost());
        myMonsters.Add(new HungryMoster());
        myMonsters.Add(new BleakDog());
        myMonsters.Add(new ScarletLimax());
        myMonsters.Add(new EyeLimax());
        myMonsters.Add(new BlackBarrier());
        myMonsters.Add(new CornerSheep());
    }

    // 单例类
    private static MonsterFactory instance = null;

    // 单例获取函数
    public static MonsterFactory GetInstance()
    {
        if (instance == null)
            instance = new MonsterFactory();

        return instance;
    }

    private List<Monster> myMonsters;

    // 获得怪物
    public Monster GetMonster(int index)
    {
        return myMonsters[index];
    }
}
