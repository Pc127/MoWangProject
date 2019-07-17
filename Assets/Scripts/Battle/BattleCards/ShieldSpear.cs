using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpear : BattleCard
{
    public ShieldSpear()
    {
        this.name = "茅与盾";
        this.explaination = "当前回合翻倍物理防御，并造成物理伤害（物理防御*1） ";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "教会的骑士们会用光芒法术武装自己，在身上覆上一层光芒荆棘，能够加强自己的防御同时对敌人造成伤害。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.physicalDefense = Hero.GetInstance().physicalDefense;
        info.physicalAttack = info.physicalDefense * 2;

        return info;
    }
}

