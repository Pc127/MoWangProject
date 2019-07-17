using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeLimax : Monster
{
    public EyeLimax()
    {
        this.physicalAttack = 0;
        this.physicalDefense = 0;
        this.spellAttack = 20;
        this.spellDefense = 0;
        this.health = 1000;

        this.name = "蛞蝓加恩";
        this.explaination = "纯粹的魔法生物";
        this.story = "似乎是猩红蛞蝓成长起来的魔物，头部有一只巨大的眼睛，并且长出了双臂，腹部布满了脓疮一样的疱疹。它们可以在更大的范围内活动，不再只能生存在泥塘之中，被小镇的居民们冠以了加恩的名字，出处却没人能说清楚了";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.spellAttack = this.spellAttack;
        info.physicalAttack = this.physicalAttack;
        return info; ;
    }
}