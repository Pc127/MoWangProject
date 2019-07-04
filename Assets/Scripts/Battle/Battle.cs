using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfo
{
    // 造成的物理攻击
    public int pa;

    // 造成的魔法攻击
    public int sa;

    // 增加的魔法防御
    public int sd;

    // 增加的物理防御
    public int pd;

    // 回复的血量
    public int recoverHealth;

    // 累加
    public void Superposition(BattleInfo other)
    {
        pa += other.pa;
        sa += other.sa;
        sd += other.sd;
        pd += other.pd;
        recoverHealth += other.recoverHealth;
    }
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
        monster.health -= heroAttack.pa - monster.physicalDefense >0 ? heroAttack.pa - monster.physicalDefense : 0;
        hero.health -= monsterAttack.pa - hero.physicalDefense > 0 ? monsterAttack.pa - hero.physicalDefense : 0;

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
        monster.health -= heroAttack.sa - monster.spellDefense > 0 ? heroAttack.sa - monster.spellDefense : 0;
        hero.health -= monsterAttack.sa - hero.physicalDefense > 0 ? monsterAttack.pa - hero.physicalDefense : 0;

        Debug.Log("战斗完英雄血量" + hero.health);
    }

    public static void HeroDie()
    {
        GamePlay.GetInstance().die.HeroDie();
    }

    public static void MonsterDie(Monster monster)
    {
        monster.live = false;
    }
    
}
