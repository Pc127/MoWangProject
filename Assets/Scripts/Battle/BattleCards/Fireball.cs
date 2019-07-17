using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BattleCard
{
    public Fireball()
    {
        this.name = "火球";
        this.explaination = "进行一次魔法攻击（魔攻*0.5*骰子点数）";
        this.needDice = true;
        this.diceIndex = 0;

        this.story = "光明教会的初级法术，这个法术在光明教会诞生之前便已经存在，法术在民间亦有普及，施法者从以太中汲取能量产生火焰，并且够抛出它制造伤害。";
    }

    // 火球
    // 进行魔法攻击
    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();
        // 魔法攻击基于掷骰子的点数
        info.spellAttack = (int)(Hero.GetInstance().spellAttack * this.diceIndex*0.5);

        return info;
    }
}
