using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : BattleCard
{
    public RunAway()
    {
        this.name = "逃跑";
        this.explaination = "结束当前回合战斗，但会受到攻击";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "三十六计策走为上";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();
        // 会被打
        // 逃跑的逻辑 在battleUI里面 这里是单纯的被打
        return info;
    }
}