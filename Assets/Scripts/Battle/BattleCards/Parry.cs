using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : BattleCard
{
    public Parry()
    {
        this.name = "格挡";
        this.explaination = "当前回合翻倍物理防御";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "教会骑士团的基础格斗技之一，以防守姿态抵挡敌人本回合的进攻，仅对物理攻击有效。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.physicalDefense = Hero.GetInstance().physicalDefense;

        return info;
    }
}
