using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBrokenKnight : Monster
{
    public ArmBrokenKnight()
    {
        this.physicalAttack = 60;
        this.physicalDefense = 15;
        this.spellAttack = 0;
        this.spellDefense = 15;
        this.health = 200;

        this.name = "断臂骑士巴利斯坦的陵墓";
        this.explaination = "恶灵骑士，1.5倍物理攻击";
        this.story = "巴利斯坦曾是教会中最强大的骑士之一，尽管他在战斗中失去了双臂，但依然口咬骑士团巨型双刃剑战斗，强大程度丝毫不减，小镇的人们十分的敬重他。在黑教诞生的前夕，巴利斯坦离奇死亡，没有人知道他死亡的真相。小镇的人们将巴利斯坦厚葬在小镇西边的森林入口，希望他的亡躯依然可以保护小镇不被魔物侵扰";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        // 普通物理攻击
        info.physicalAttack = (int)(this.physicalAttack*1.5);
        info.selfPhysicalDemage = 30;
        return info; ;
    }

    public override void Die()
    {
        base.Die();
        BattleCardArray.GetInstance().AddBattleCard(new BrightSpear());
        BattleCardArray.GetInstance().AddBattleCard(new ShieldSpear());
        BattleCard[] cards = new BattleCard[2] { new BrightSpear(), new ShieldSpear() };
        EventManager.GetInstance().getCardUI.InitialCard(cards);
    }
}
