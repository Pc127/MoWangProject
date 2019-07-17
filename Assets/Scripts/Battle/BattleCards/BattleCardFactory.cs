using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardFactory : MonoBehaviour
{
    // 私有构造函数
    private BattleCardFactory()
    {
        myCards = new List<BattleCard>();

        myCards.Add(new JumpCut());
        myCards.Add(new Fireball());
    }

    // 单例类
    private static BattleCardFactory instance = null;

    // 单例获取函数
    public static BattleCardFactory GetInstance()
    {
        if (instance == null)
            instance = new BattleCardFactory();

        return instance;
    }

    private List<BattleCard> myCards;

    public BattleCard GetBattleCard(int index)
    {
        BattleCard battle = myCards[index];

        return battle;
    }

    // 随机获得一张卡牌
    public BattleCard GetRandomCard()
    {
        int index = Random.Range(0, myCards.Count);
        BattleCard card = myCards[index];

        return card;
    }
}
