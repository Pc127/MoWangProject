using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBrokenKnight : Monster
{
    public ArmBrokenKnight()
    {
        this.physicalAttack = 100;
        this.physicalDefense = 30;
        this.spellAttack = 0;
        this.spellDefense = 30;
        this.health = 1000;

        this.name = "断臂骑士巴利斯坦的亡躯";
        this.explaination = "恶灵骑士，物理攻击";
        this.story = "巴利斯坦曾是教会中最强大的骑士之一，尽管他在战斗中失去了双臂，但依然口咬骑士团巨型双刃剑战斗，强大程度丝毫不减，小镇的人们十分的敬重他。在黑教诞生的前夕，巴利斯坦离奇死亡，没有人知道他死亡的真相。小镇的人们将巴利斯坦厚葬在小镇西边的森林入口，希望他的亡躯依然可以保护小镇不被魔物侵扰";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        // 普通物理攻击
        info.physicalAttack = this.physicalAttack;
        return info; ;
    }
}
