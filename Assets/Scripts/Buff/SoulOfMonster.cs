using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulOfMonster : Buff
{
    public SoulOfMonster(int point)
    {
        this.level = 2;
        this.point = point;
        this.explaination = "每一个圣殿骑士都能够在战斗中不断地学习和进步，通过对魔物灵魂的识破，会增加战斗技艺";
        this.name = "魂识";
    }

    public override string Attribute()
    {
        return "杀死怪物+" + point + "物理攻击/魔法攻击";

    }

    public override void KillMonster()
    {
        base.KillMonster();
        Hero.GetInstance().physicalAttack += (int)point;
        Hero.GetInstance().spellAttack += (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
