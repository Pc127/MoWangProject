using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEdgeSword : BattleCard
{
    public DoubleEdgeSword()
    {
        this.name = "双刃剑";
        this.explaination = "对敌方与自身同时造成物理攻击（敌方：物攻*3，自身：物攻*1）";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "被教会骑士团为是异端格斗技，但不可否认其虽然会对自身造成伤害，但是在战斗中有极为可观的收益。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        int i = Hero.GetInstance().physicalAttack;

        info.selfPhysicalDemage = i;
        info.physicalAttack = 3 * i;

        return info;
    }
}
