using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : BattleCard
{
    public Recovery()
    {
        this.name = "大回复术";
        this.explaination = "回复50血量";
        this.needDice = false;
        this.diceIndex = 0;
        this.attackType = 1;

        this.story = "召唤治愈的光芒，接受光芒的祝福，能从流溢的世界精神之中获取修复自身的能量。";
    }

    // 火球
    // 进行魔法攻击
    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.healthReflash = 50;

        return info;
    }
}
