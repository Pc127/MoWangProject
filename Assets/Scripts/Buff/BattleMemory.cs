using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMemory : Buff
{
    public BattleMemory(int point)
    {
        this.point = point;
        this.explaination = "对于一个武者，战斗记忆比他的剑更加锋利";
        this.name = "战斗记忆";
        this.attribute = "+" + point + "物理攻击";
    }


    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().physicalAttack += (int)point;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Hero.GetInstance().physicalAttack -= (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }

}
