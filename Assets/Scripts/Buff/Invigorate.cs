using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invigorate : Buff
{
    public Invigorate(int point)
    {
        this.level = 2;
        this.point = point;
        this.explaination = "活血带来新的生命力";
        this.name = "活血";
    }

    public override string Attribute()
    {
        return "增加+" + point + "血量上限";
    }

    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().healthMax += (int)(point);
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
