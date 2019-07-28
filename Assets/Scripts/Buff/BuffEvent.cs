using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEvent
{
    // 一次buff事件 保存两个buff供选择
    public Buff buffOne;
    public Buff buffTwo;
}


public class BuffEventMap
{
    public BuffEventMap(int count)
    {
        this.count = count;
        // 创建相应数量的buff
        myBuffs = new BuffEvent[count];
    }

    // 棋盘格数
    int count;

    // 棋盘信息 每格的buff等级
    // public int[] myBuffLevel;
    public BuffEvent[] myBuffs;

    // 获取棋盘上的Buff
    public BuffEvent GetBuff(int index)
    {
        BuffEvent re = new BuffEvent
        {
            buffOne = myBuffs[index].buffOne.Clone(),
            buffTwo = myBuffs[index].buffTwo.Clone()
        };
        return re;
       // return BuffFactory.GetInstance().GetBuffEvent(myBuffLevel[index]);
    }
}

public class BuffFactory
{
    private BuffFactory()
    {
        buffDic = new Dictionary<int, List<Buff>>();

        // 等级1的buff
        List<Buff> levelOne = new List<Buff>();
        levelOne.Add(new BattleMemory(5));
        levelOne.Add(new ElementPerception(5));
        levelOne.Add(new DodgeAwareness(5));
        levelOne.Add(new ShieldOfSoul(5));
        levelOne.Add(new Coalescence(2));

        // 等级2 的buff
        List<Buff> levelTwo = new List<Buff>();
        levelTwo.Add(new SoulOfMonster(10));
        levelTwo.Add(new LuckTouch(20));
        levelTwo.Add(new PrickyArmour(5));
        levelTwo.Add(new Harvest(5));

        // 等级3的buff
        List<Buff> levelThree = new List<Buff>();
        levelThree.Add(new BloodCeremony());
        levelThree.Add(new GloryBlessing());

        buffDic.Add(1, levelOne);
        buffDic.Add(2, levelTwo);
        buffDic.Add(3, levelThree);
    }

    // 单例类
    private static BuffFactory instance = null;

    // 单例获取函数
    public static BuffFactory GetInstance()
    {
        if (instance == null)
            instance = new BuffFactory();

        return instance;
    }

    // 获取随机buff
    public BuffEvent GetBuffEvent(int level)
    {
        List<Buff> buff = buffDic[level];

        int first = Random.Range(0, buff.Count);
        int second = Random.Range(0, buff.Count);
        while(second == first)
        {
            second = Random.Range(0, buff.Count);
        }

        BuffEvent be = new BuffEvent();
        be.buffOne = buff[first].Clone();
        be.buffTwo = buff[second].Clone();

        return be;
    }

    private Dictionary<int, List<Buff>> buffDic;
}