using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BattleCard
{
    public Fireball()
    {
        this.name = "火球";
        this.explaination = "进行魔法攻击";
        this.needDice = true;
        this.diceIndex = 0;
    }

    // 火球
    // 进行魔法攻击
    public override BattleInfo InvokeCard()
    {
        BattleInfo info = new BattleInfo();
        // 魔法攻击基于掷骰子的点数
        info.sa = Hero.GetInstance().spellAttack * this.diceIndex;

        return info;
    }
}
