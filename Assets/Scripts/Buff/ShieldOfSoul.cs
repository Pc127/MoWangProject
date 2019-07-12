using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfSoul : Buff
{
    public ShieldOfSoul(int point)
    {
        this.level = 1;
        this.point = point;
        this.explaination = "用以太为介质的魔法攻击的对象是心灵，古代的贤者，通过修炼自己的心灵来使其不受魔法的侵扰";
        this.name = "心灵壁垒";
        this.attribute = "+" + point + "魔法防御";
    }


    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().spellDefense += (int)point;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Hero.GetInstance().spellDefense-= (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
