using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCut : BattleCard
{
    // 跳劈
    // 进行100%物理攻击
    public override BattleInfo InvokeCard()
    {
        BattleInfo info = new BattleInfo();
        info.pa = Hero.GetInstance().physicalAttack;

        return info;

    }
}
