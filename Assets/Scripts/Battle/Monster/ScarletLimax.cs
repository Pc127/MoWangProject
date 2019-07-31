using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarletLimax : Monster
{
    public ScarletLimax()
    {
        this.physicalAttack = 0;
        this.physicalDefense = 2;
        this.spellAttack = 15;
        this.spellDefense = 2;
        this.health =30;

        this.name = "猩红蛞蝓";
        this.explaination = "魔法攻击，1倍魔攻，附带生命偷取效果";
        this.story = "周身血红并分泌着血红黏液的蛞蝓，潜藏在泥塘之中，不容易被人们发现，所以小镇的人们看见泥塘都会避让不及。根据镇中老者们的记忆，在光芒教会的天才术士小李失踪，教会分裂之前，泥塘中的蛞蝓都还是乳白色的，并且不具有攻击性";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.spellAttack = this.spellAttack;
        info.spellBloodSuck= 1;
        return info; ;
    }
}
