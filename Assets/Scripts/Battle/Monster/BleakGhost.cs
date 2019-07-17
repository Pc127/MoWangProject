using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleakGhost : Monster
{
    public BleakGhost()
    {
        this.physicalAttack = 0;
        this.physicalDefense = 30000;
        this.spellAttack = 100;
        this.spellDefense = 0;
        this.health = 1000;

        this.name = "凄色之幽";
        this.explaination = "纯粹的魔法生物";
        this.story = "凄色之幽是堕入黑暗面的灵魂，它们早已失去了肉体，因此物理攻击对它们完全无效，光芒教会的骑士们用光芒法术对抗凄色之幽。但是人们发现凄色之幽的数量似乎并没有减少，反而不断地增多";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.spellAttack = this.spellAttack;
        return info; ;
    }
}