using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrickyArmour : Buff
{
    public PrickyArmour(int point)
    {
        this.level = 2;
        this.point = point;
        this.explaination = "远古光明教会为骑士们特别打造的盔甲，表面覆满了细小的尖刺，这种尖刺不仅会对物理的攻击进行反弹，也能反弹魔法的攻击。可惜尖刺盔甲的打造工艺已经失传，只有很少的数量还流传于世";
        this.name = "尖刺盔甲";
    }


    public override string Attribute()
    {
        return "反弹" + point + "%魔物攻击";
    }


    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().strikeBack += (int)point;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        Hero.GetInstance().strikeBack -= (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
