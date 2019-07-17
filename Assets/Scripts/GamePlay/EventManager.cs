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
        currentMonsters = GamePersist.GetInstance().GetMonsterEvents();
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

    // 当前关卡的战斗信息
    private MonsterEvents currentMonsters;

    // buff相关的ui逻辑
    public BuffUI buffUI;

    // 战斗
    public BattleUI battleUI;

    // 获得卡牌ui
    public GetCardUI getCardUI;

    // 触发事件
    public void InvokeEvent()
    {
        int heroPos = GamePlay.GetInstance().heroPos;

        // 先检查怪物
        Monster m = currentMonsters.GetMonster(heroPos);

        Debug.Log(m);

        if(m != null)
        {
            GamePlay.GetInstance().monsterLoad.LoadMonster(m.name, heroPos);
            // 触发战斗
            battleUI.BattleVsMonster(m);
            return;
        }

        // 触发buff事件
        buffUI.GetBuffEvent(currentBuffs.GetBuff(heroPos));

    }

    // 判断是否会被怪物拦下
    public bool MeetMonster(int heropos)
    {
        return currentMonsters.GetCurrentMonster(heropos);
    }
}
