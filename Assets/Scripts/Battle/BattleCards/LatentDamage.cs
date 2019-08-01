using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatentDamage : BattleCard
{
    public LatentDamage()
    {
        this.name = "艾琳的印记符卡";
        this.explaination = "造成一次魔法攻击，下次使用时，伤害翻倍（魔法伤害*1）";
        this.needDice = false;
        this.diceIndex = 0;
        this.attackType = 1;

        this.story = "在敌人身上留下印记，印记具有光明的力量，汲取以太积蓄能量，在下一次画出印记时引爆积蓄的能量。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.spellAttack = monster.UseLatentDamage() * Hero.GetInstance().spellAttack;

        return info;
    }
}