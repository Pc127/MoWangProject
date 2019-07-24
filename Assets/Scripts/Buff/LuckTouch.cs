using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckTouch : Buff
{
    public LuckTouch(int point)
    {
        this.level = 2;
        this.point = point;
        this.explaination = "圣殿骰子具有被光明圣教祝福的力量，只要洞悉了圣骰的神秘，便可以在掷出特殊数字时获得力量";
        this.name = "幸运触碰";
    }

    public override string Attribute()
    {
        return "每次掷到六时+" + point + "魔法攻击";
    }

    public override void Dice(int diceIndex)
    {
        base.Dice(diceIndex);
        if(diceIndex == 6)
        {
            Hero.GetInstance().spellAttack += (int)point;
        }
    }

    public override void Superposition(Buff other)
    {
        base.Superposition(other);

        // 累加
        this.point += other.point;
    }
}
