using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxin : BattleCard
{
    public Toxin()
    {
        this.name = "叠加毒素";
        this.explaination = "为敌方叠加一层毒素（叠加到3层，造成1000点魔法伤害）";
        this.needDice = false;
        this.diceIndex = 0;
        this.attackType = 2;
        this.story = "教会的异端法术，出处已不可考，只有老骑士们知道怎么使用这个法术，使用得当，能够轻易的打败任何敌人。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        monster.UseToxin();

        return info;
    }
}