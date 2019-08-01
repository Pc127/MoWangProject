using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightSpear : BattleCard
{
    public BrightSpear()
    {
        this.name = "光芒圣枪";
        this.explaination = "进行一次魔法攻击（魔攻*(2+点数)）";
        this.needDice = true;
        this.diceIndex = 0;
        this.attackType = 1;

        this.story = "光明教会的高阶法术，用以太凝聚而成的闪耀着光芒的魔法长枪，由光明教会的初代教主小红开发。光芒圣枪充满着神圣的力量，能制造巨大的伤害。";
    }

    // 火球
    // 进行魔法攻击
    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();
        // 魔法攻击基于掷骰子的点数
        info.spellAttack = (int)(Hero.GetInstance().spellAttack * (2 + this.diceIndex));

        return info;
    }
}
