using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardArray
{
    // 私有构造函数
    private BattleCardArray()
    {
        myCards = new List<BattleCard>();
    }

    // 单例类
    private static BattleCardArray instance = null;

    // 单例获取函数
    public static BattleCardArray GetInstance()
    {
        if (instance == null)
            instance = new BattleCardArray();

        return instance;
    }

    // 保存当前身上的Card
    public List<BattleCard> myCards;


    // 加入一张卡片
    public void AddBattleCard(BattleCard bc)
    {
        myCards.Add(bc);
    }

    // 重新刷新所有的卡牌
    public void Reflash()
    {
        foreach(var card in myCards)
        {
            card.active = true;
        }
    }
}
