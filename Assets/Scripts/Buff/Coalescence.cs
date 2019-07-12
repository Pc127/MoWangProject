using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coalescence : Buff
{
    public Coalescence(int point)
    {
        this.level = 1;
        this.point = point;
        this.explaination = "强大的灵魂可以在时间流逝中自动修复伤痕，据《光芒圣典》的记载，灵魂能够从宇宙中弥散的以太中获得修复的质料，并由灵魂去修复肉身";
        this.name = "流动愈合";
        this.attribute = "每行动一格+" + point + "血量";
    }

    public override void MoveStep(int stepCount)
    {
        base.MoveStep(stepCount);
        Hero.GetInstance().health +=(int)(stepCount * this.point);
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
