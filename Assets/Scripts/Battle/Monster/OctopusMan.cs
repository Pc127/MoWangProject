﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusMan : Monster
{
    public OctopusMan()
    {
        this.physicalAttack = 40;
        this.physicalDefense = 15;
        this.spellAttack = 40;
        this.spellDefense = 10;
        this.health = 150;

        this.name = "章鱼人";
        this.explaination = "物理魔法，混合攻击";
        this.story = "在河边散发恶臭的章鱼人，它身上有腐烂的痕迹，脸上和手上都生长着很多触手，它穿着人类的衣服，看上去就像以前是人类，在每根触手的根部交接的地方隐约可见缝补的痕迹";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        // 普通物理攻击
        info.physicalAttack = this.physicalAttack;
        info.spellAttack = this.spellAttack;

        this.physicalAttack += 1;
        this.spellAttack += 1;
        return info; ;
    }
}
