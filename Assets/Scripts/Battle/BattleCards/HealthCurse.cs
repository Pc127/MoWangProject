using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCurse : BattleCard
{
    public HealthCurse()
    {
        this.name = "阿尔德谬的生命消散符卡";
        this.explaination = "消散对方50%生命值（骰子点数=6） ";
        this.needDice = true;
        this.diceIndex = 0;

        this.story = "由光明教会的传奇战斗法师阿尔德谬开发的符卡，在光芒圣骰的选择下，能够消散摸鱼一般的灵魂，但是成功率很低。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        if (this.diceIndex == 6)
        {
            monster.health -= (int)(monster.health * 0.5);
        }

        return info;
    }
}
