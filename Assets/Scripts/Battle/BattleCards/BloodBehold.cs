using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBehold : BattleCard
{
    public BloodBehold()
    {
        this.name = "吸血之握";
        this.explaination = "造成基于对方生命数值的魔法伤害，并回复造成伤害数值的血量（敌方生命值*0.1*骰子点数）";
        this.needDice = true;
        this.diceIndex = 0;

        this.story = "光明教会的高阶法术，能够汲取敌人的灵魂力量，回复自身的血量。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.spellAttack = (int)(this.diceIndex * monster.health * 0.1f);
        info.spellBloodSuck = 1;
        return info;
    }
}