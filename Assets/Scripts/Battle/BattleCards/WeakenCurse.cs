using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakenCurse : BattleCard
{
    public WeakenCurse()
    {
        this.name = "阿尔德谬的弱小诅咒符卡";
        this.explaination = "削减敌方30%物理&魔法攻击（骰子点数>3） ";
        this.needDice = true;
        this.diceIndex = 0;

        this.story = "由光明教会的传奇战斗法师阿尔德谬开发的符卡，在光芒圣骰的选择下，能够削弱魔物很大部分能力。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        if (this.diceIndex > 3)
        {
            monster.physicalAttack -= (int)(monster.physicalAttack * 0.3);
            monster.spellAttack -= (int)(monster.spellAttack * 0.3);
        }

        return info;
    }
}
