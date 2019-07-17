using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCut : BattleCard
{
    public JumpCut()
    {
        this.name = "跳劈";
        this.explaination = "进行一次物理攻击（物攻*1）";
        this.needDice = false;

        this.story = "光明教会骑士团的基础格斗技之一，纵跳起来劈砍，能造成一定的物理伤害。";
    }

    // 跳劈
    // 进行100%物理攻击
    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();
        info.physicalAttack = Hero.GetInstance().physicalAttack;

        return info;
    }
}
