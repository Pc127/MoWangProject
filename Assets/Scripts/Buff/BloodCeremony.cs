using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCeremony : Buff
{
    public BloodCeremony()
    {
        this.level = 3;
        this.explaination = "黑教内部的不传秘术，鲜血沾染了灵魂的气味，可以成为比以太更好的魔法介质";
        this.name = "鲜血盛宴";
        this.attribute = "损失的生命会对怪物产生真实伤害";
    }

    public override void OnAcquire()
    {
        base.OnAcquire();
        Hero.GetInstance().bloodCeremony = true;
    }
}
