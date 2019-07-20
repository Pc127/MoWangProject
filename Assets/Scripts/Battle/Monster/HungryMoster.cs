using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungryMoster : Monster
{
    public HungryMoster()
    {
        this.physicalAttack = 15;
        this.physicalDefense = 5;
        this.spellAttack = 0;
        this.spellDefense = 5;
        this.health = 40;

        this.name = "饿兽";
        this.explaination = "凶猛的野兽";
        this.story = "饿兽看上去就像人变成的狼，同时具有人和狼的特征，人们相信饿兽是被黑教创造出来的怪物。森林里曾偶尔能目击饿兽，但是最近森林里目击到饿兽的次数越来越多，甚至有饿兽出现在了城镇当中";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.spellAttack = this.spellAttack;
        this.health += 20;
        return info; ;
    }
}