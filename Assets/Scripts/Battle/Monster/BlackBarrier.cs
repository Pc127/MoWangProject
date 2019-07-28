using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBarrier : Monster
{
    public BlackBarrier()
    {
        this.physicalAttack = 0;
        this.physicalDefense = 0;
        this.spellAttack = 0;
        this.spellDefense = 0;
        this.health = 100;

        this.name = "黑石壁垒";
        this.explaination = "坚硬的魔法生物，会反弹伤害";
        this.story = "阻挡在森林入口的壁垒，没有人知道它从哪儿来的，也没有人想搞清楚它是什么，因为没有人想靠近西边的森林";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.physicalDemageRevert = 0.3f;
        info.spellDemageRevert = 0.3f;
        return info; ;
    }
}
