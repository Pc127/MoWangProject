using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfo
{
    // 造成的物理攻击
    public int physicalAttack;

    // 造成的魔法攻击
    public int spellAttack;

    // 增加的魔法防御
    public int spellDefense;

    // 增加的物理防御
    public int physicalDefense;

    // 物理吸血
    public float physicBloodSuck;

    // 魔法吸血
    public float spellBloodSuck;

    // 自身伤害数值
    public int selfDemage;

    // 自身伤害加深
    public float selfInjury;

    // 伤害返回系数
    public float demageRevert;

    // 魔法伤害反弹
    public float spellRebound;

    // 物理伤害反弹
    public float physicalRebound;
}



public class Battle
{
    // 进行战斗的计算
    public static void StartBattle(Monster monster, params BattleCard[] cards)
    {
        // 主角
        Hero hero = Hero.GetInstance();

        // 怪物的攻击信息
        BattleInfo monsterAttack = monster.MakeAttack();

        // 人物的攻击信息
        BattleInfo heroAttack = new BattleInfo();

        foreach(BattleCard bc in cards)
        {
            // 累加卡牌效应
            heroAttack.Superposition(bc.InvokeCard());
        }

        // 计算伤害

        // 物理
        monster.health -= heroAttack.physicalAttack - monster.physicalDefense >0 ? heroAttack.physicalAttack - monster.physicalDefense : 0;
        hero.health -= monsterAttack.physicalAttack - hero.physicalDefense > 0 ? monsterAttack.physicalAttack - hero.physicalDefense : 0;

        if(monster.health <= 0)
        {
            monster.health = 0;
            MonsterDie(monster);
        }

        if(hero.health <= 0)
        {
            hero.health = 0;
            HeroDie();
        }
        // 魔法
        monster.health -= heroAttack.spellAttack - monster.spellDefense > 0 ? heroAttack.spellAttack - monster.spellDefense : 0;
        hero.health -= monsterAttack.spellAttack - hero.physicalDefense > 0 ? monsterAttack.physicalAttack - hero.physicalDefense : 0;

        Debug.Log("战斗完英雄血量" + hero.health);
    }

    public static void HeroDie()
    {
        GamePlay.GetInstance().die.HeroDie();
    }

    public static void MonsterDie(Monster monster)
    {
        monster.live = false;
        monster.Die();
    }
    
}
