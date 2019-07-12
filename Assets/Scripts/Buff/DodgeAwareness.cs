using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAwareness : Buff
{
    public DodgeAwareness(int point)
    {
        this.level = 1;
        this.point = point;
        this.explaination = "战场上存活的老兵，比起战斗，似乎更注重保护自己";
        this.name = "闪避意识";
        this.attribute = "+" + point + "物理防御";
    }


    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().physicalDefense += (int)point;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Hero.GetInstance().physicalDefense -= (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
