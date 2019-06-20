using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPerception : Buff
{
    public ElementPerception(int point)
    {
        this.point = point;
        this.explaination = "以太的力量来源于“世界精神”，逸散于整个大气，与人类的灵魂拥有相同的质料——《光芒圣典》记载";
        this.name = "元素感知";
        this.attribute = "+" + point + "魔法攻击";
    }


    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().spellAttack += (int)point;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Hero.GetInstance().spellAttack -= (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
