using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeat : BattleCard
{
    public Repeat()
    {
        this.name = "空白符卡";
        this.explaination = "再次触发上一回合的战斗牌效果";
        this.needDice = false;
        this.diceIndex = 0;
        this.attackType = 1;

        this.story = "空白符卡是一种稀有的符卡，能够复制上一张符卡的效果，当拥有强大的符卡时，使用空白符卡复制强大的符卡，能够达成成倍的收益。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleCard battleCard;

        battleCard = EventManager.GetInstance().battleUI.lastCard;

        if(battleCard == null)
        {
            battleCard = new Fireball();
        }

        return battleCard.InvokeCard(monster);
    }
}