using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCut : BattleCard
{
    public JumpCut()
    {
        this.name = "跳劈";
        this.explaination = "进行一次物理攻击";
    }

    // 跳劈
    // 进行100%物理攻击
    public override BattleInfo InvokeCard()
    {
        BattleInfo info = new BattleInfo();
        info.pa = Hero.GetInstance().physicalAttack;

        return info;

    }
}
