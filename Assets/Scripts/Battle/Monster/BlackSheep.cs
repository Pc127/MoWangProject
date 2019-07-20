using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSheep : Monster
{
    // 一只 只会进行普通攻击的小怪
    public BlackSheep()
    {
        this.physicalAttack = 100;
        this.physicalDefense = 50;
        this.spellAttack = 0;
        this.spellDefense = 50;
        this.health = 250;

        this.name = "黑羊崔西";
        this.explaination = "黑色的羊，普通物理攻击";
        this.story = "自光明教会内部分裂并诞生禁忌的黑教以来，便有各种目击到黑羊崔西的传说，他无比的强大，目击到他的人都说他手持一柄巨型的长枪，而且据说与他对视过的人都神秘失踪了。关于那些失踪的人坊间有各种传说，有人说他们变成了黑羊崔西的盘中餐，也有人说他们被黑羊崔西引导到了另一个世界，真相究竟是什么呢？";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        // 普通物理攻击
        info.physicalAttack = this.physicalAttack;
        return info; ;
    }
}
