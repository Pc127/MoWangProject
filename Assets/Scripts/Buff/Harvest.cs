using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : Buff
{
    public Harvest(int point)
    {
        this.level = 2;
        this.point = point;
        this.explaination = "世界中散布着从“世界意志”流溢而来的以太，在周而复始的循环战斗中，人的灵魂可以逐渐洞悉世界的本质，并从其中获取到永久的力量";
        this.name = "收获";
    }

    public override string Attribute()
    {
        return "每走一圈+" + point + "全属性";
    }

    public override void RoundOver()
    {
        base.RoundOver();
        Hero.GetInstance().spellAttack += (int)point;
        Hero.GetInstance().spellDefense += (int)point;
        Hero.GetInstance().physicalAttack += (int)point;
        Hero.GetInstance().physicalDefense += (int)point;
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
