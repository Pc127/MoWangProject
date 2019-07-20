using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerSheep : Monster
{
    public CornerSheep()
    {
        this.physicalAttack = 20;
        this.physicalDefense = 10;
        this.spellAttack = 0;
        this.spellDefense = 10;
        this.health = 100;

        this.name = "绒毛犄角";
        this.explaination = "看似可爱的恶魔生物";
        this.story = "像是绵羊一样的魔物，看上去很可爱，常常让人忘记它的危险，实际上任何理智的人都不会去招惹这种魔物。它蓬松的皮毛能吸收大部分攻击，而它的犄角能对人造成巨大的伤害，十分难缠";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.physicalAttack = this.physicalAttack;

        // 30%概率 吸血10%
        if (Random.Range(0, 1) < 0.3)
        {
            int count = (int)(Hero.GetInstance().health * 0.1);
            Hero.GetInstance().health -= count;
            this.health += count;
        }
        return info; ;
    }
}
