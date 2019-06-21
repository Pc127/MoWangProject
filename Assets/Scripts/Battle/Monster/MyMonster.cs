using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMonster : Monster
{
    // 一只 只会进行普通攻击的小怪
    public MyMonster(int pa, int sa, int pd, int sd, int ph):base(pa, sa, pd, sd, ph)
    {
        this.name = "小怪";
        this.explaination = "一只 只会进行普通物理攻击的小怪";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        // 普通物理攻击
        info.pa = this.physicalAttack;
        return info; ;
    }
}
