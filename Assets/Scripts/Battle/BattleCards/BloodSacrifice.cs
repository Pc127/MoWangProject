﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSacrifice : BattleCard
{
    public BloodSacrifice()
    {
        this.name = "鲜血献祭";
        this.explaination = "自身收到2倍伤害，返回5倍伤害（单倍为魔攻×0.5×点数）";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "以鲜血为媒介，能够将自己的灵魂暂时寄托给黑暗面。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.selfInjury = 2;
        info.physicalDemageRevert = 5;
        info.spellDemageRevert = 5;

        return info;
    }
}
