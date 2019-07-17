using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRebound : BattleCard
{
    public MagicRebound()
    {
        this.name = "艾琳的魔法反制符卡";
        this.explaination = "反弹当前魔法攻击（骰子点数>2）";
        this.needDice = true;
        this.diceIndex = 0;

        this.story = "光明教会的大法师艾琳开发的符卡，在光明圣骰的选择之下，能够全额反弹敌人的魔法攻击。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        if (this.diceIndex > 2)
        {
            info.spellRebound = 1;
        }

        return info;
    }
}