using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    // 私有构造
    private EventManager()
    {
        NewSceneUpdate();
        circulCount = 0;
    }

    public void NewSceneUpdate()
    {
        // 获取当前的buffs
        currentBuffs = GamePersist.GetInstance().GetBuffEvents();
        currentMonsters = GamePersist.GetInstance().GetMonsterEvents();
        currentCards = GamePersist.GetInstance().GetBattleCardMap();
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
    private BuffEventMap currentBuffs;

    // 当前关卡的战斗信息
    private MonsterEventMap currentMonsters;

    // 当前关卡的卡牌信息
    private BattleCardMap currentCards;

    // buff相关的ui逻辑
    public BuffUI buffUI;

    // 战斗
    public BattleUI battleUI;

    // 获得卡牌ui
    public GetCardUI getCardUI;

    // 选择卡牌ui
    public ChooseCardUI chooseCardUI;

    // Log
    public LogUI logUI;

    // 当前圈数
    public int circulCount;

    // 触发事件
    public void InvokeEvent()
    {
        NewSceneUpdate();

        int heroPos = GamePlay.GetInstance().heroPos;

        // 只有前两圈 会有遮蔽
        if (circulCount > 2)
            circulCount = 2;
        // 先检查怪物
        Monster m = currentMonsters.GetMonster(heroPos, GamePersist.GetInstance().GetLevelCull()[circulCount]);

        if(m != null)
        {
            GamePlay.GetInstance().monsterLoad.LoadMonster(m.name, heroPos);
            // 触发战斗
            battleUI.BattleVsMonster(m);
            return;
        }

        BattleCardEvent cardEvent = currentCards.GetBattleCardEvent(heroPos);

        if(cardEvent != null)
        {
            // 调用卡牌选择事件
            chooseCardUI.MakeCardChoose(cardEvent.one, cardEvent.two);
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
