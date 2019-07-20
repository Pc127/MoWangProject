using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgainCard : BattleCard
{
    public MoveAgainCard()
    {
        this.name = "再次移动";
        this.explaination = "遭受伤害，但进行指定格数的移动（格数1-6）";
        this.needDice = false;
        this.diceIndex = 0;

        this.story = "能够多投一次光明圣骰请求自动，但是不可避免的要被敌人伤害一次。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();
        // 显示move again
        EventManager.GetInstance().battleUI.ShowMoveAgain();
        return info;
    }
}