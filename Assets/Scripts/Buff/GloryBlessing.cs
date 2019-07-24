using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloryBlessing : Buff
{
    public GloryBlessing()
    {
        this.level = 3;
        this.explaination = "光芒教会的不传秘术，圣光是世界精神的流溢，是宇宙之源，从魔物那里获取到的力量能够为己所用";
        this.name = "圣光祝福";
    }

    public override string Attribute()
    {
        return "造成的伤害回复相应生命值"; ;
    }

    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().gloryBlessing = true;
    }
}
