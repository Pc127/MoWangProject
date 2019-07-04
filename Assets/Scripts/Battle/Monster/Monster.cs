using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    // 怪物名称
    public string name;

    // 怪物说明
    public string explaination;

    // 物理攻击
    public int physicalAttack;

    // 魔法攻击
    public int spellAttack;

    // 物理防御
    public int physicalDefense;

    // 魔法防御
    public int spellDefense;

    // 血量
    public int health;

    public Monster(int pa, int sa, int pd, int sd, int ph)
    {
        // 初始化属性
        physicalAttack = pa;
        spellAttack = sa;
        physicalDefense = pd;
        spellDefense = sd;
        health = ph;
        live = true;
    }

    public virtual BattleInfo MakeAttack()
    {
        return new BattleInfo();
    }

    // 判断是否存活
    public bool live;

}
