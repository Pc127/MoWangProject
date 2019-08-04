using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Monster
{
    // 单例类
    private static Demon instance = null;

    // 单例获取函数
    public static Demon GetInstance()
    {

        return instance;
    }

    public Demon()
    {
        this.physicalAttack = 66;
        this.physicalDefense = 40;
        this.spellAttack = 66;
        this.spellDefense = 40;
        this.health = 166;

        this.name = "魔王迪蒙";
        this.explaination = "掌控黑暗面的永恒魔王";
        this.story = "有传闻世间的黑暗因他而生，也有传闻世间的黑暗早就了他";

        instance = this;
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.physicalAttack = this.physicalAttack;
        info.spellAttack = this.spellAttack;
        return info; ;
    }
}
