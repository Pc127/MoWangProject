using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakMan : Monster
{
    // 一只 只会进行普通攻击的小怪
    public SneakMan()
    {
        this.physicalAttack = 5;
        this.physicalDefense = 5;
        this.spellAttack = 20;
        this.spellDefense = 5;
        this.health = 50;

        this.name = "蛇人法师外破";
        this.explaination = "蛇人法师，魔法攻击";
        this.story = "外破Viper是自黑教诞生以来便时常出现在城镇中的魔物，他行踪飘忽不定，每当骑士团放松警惕时，他便会出现攻击镇民和骑士，而当骑士团们行动起来讨伐他时他又消失不见。他拿着一个法杖，上面缠着很多条毒蛇。有年长的骑士说他似乎见过那个法杖，在黑教诞生之前，但是年轻的骑士们对此不以为然。";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        // 普通物理攻击
        info.spellAttack = this.spellAttack;
        return info; ;
    }

    public override void Die()
    {
        base.Die();
        BattleCardArray.GetInstance().AddBattleCard(new WeakenCurse());
        BattleCardArray.GetInstance().AddBattleCard(new HealthCurse());
        BattleCard[] cards = new BattleCard[2] { new WeakenCurse(), new HealthCurse() };
        EventManager.GetInstance().getCardUI.InitialCard(cards);
    }
}
