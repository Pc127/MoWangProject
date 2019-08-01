using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDisturb : BattleCard
{
    public SoulDisturb()
    {
        this.name = "艾琳的心灵干扰符卡";
        this.explaination = "减少敌方魔防（骰子点数*敌方魔防*0.2）";
        this.needDice = true;
        this.diceIndex = 0;
        this.attackType = 2;

        this.story = "光明教会的大法师艾琳开发的符卡，能够根据光明圣骰的结果削弱敌方的魔法防御，配合魔法攻击能够对敌人造成巨额的伤害。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        float f = diceIndex * 0.2f;

        monster.spellDefense -= (int)(f * monster.spellDefense);

        return info;
    }
}
