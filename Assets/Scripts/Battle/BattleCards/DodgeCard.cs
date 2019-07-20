using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCard : BattleCard
{
    public DodgeCard()
    {
        this.name = "烟雾弹";
        this.explaination = "本回合不受伤害，直接脱离战斗";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "在实力悬殊时，投出烟雾弹可以避免与敌人发生战斗，也不会对自己产生伤害，等准备好之后再和强大的敌人对决也不迟。";
    }

    // 会在开始一场battle中调用
    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();
        info.dodge = true;

        EventManager.GetInstance().battleUI.Dodge();

        return info;
    }
}
