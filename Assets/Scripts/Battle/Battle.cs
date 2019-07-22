using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfo
{
    // 闪避
    public bool dodge = false;

    // 造成的物理攻击
    public int physicalAttack;

    // 造成的魔法攻击
    public int spellAttack;

    // 增加的魔法防御
    public int spellDefense;

    // 增加的物理防御
    public int physicalDefense;

    // 物理吸血 百分比
    public float physicBloodSuck;

    // 魔法吸血 百分比
    public float spellBloodSuck;

    // 自身物理伤害数值 整数
    public int selfPhysicalDemage;

    // 自身伤害加深 百分比
    public float selfInjury;

    // 伤害返回系数 百分比
    public float physicalDemageRevert;
    public float spellDemageRevert;

    // 魔法伤害反弹 百分比
    public float spellRebound;

    // 物理伤害反弹 百分比
    public float physicalRebound;
}



public class Battle
{
    // 进行战斗的计算
    public static void StartBattle(Monster monster, BattleCard card)
    {
        // 主角
        Hero hero = Hero.GetInstance();

        // 怪物的攻击信息
        BattleInfo monsterInfo = monster.MakeAttack();

        // 人物的攻击信息
        BattleInfo heroInfo = card.InvokeCard(monster);

        if (heroInfo.dodge)
        {
            return;
        }

        // 计算一下魔法反弹
        if (heroInfo.spellRebound > 0)
        {
            float count = monsterInfo.spellAttack * heroInfo.spellRebound;
            monsterInfo.spellAttack -= (int)(count);
            heroInfo.spellAttack += (int)(count);
        }
        // 物理反弹暂时没有

        // 先计算英雄打魔物
        int monsterPhysicalDemage = heroInfo.physicalAttack - monster.physicalDefense > 0 ? heroInfo.physicalAttack - monster.physicalDefense : 0;
        int monsterSpellDemage = heroInfo.spellAttack - monster.spellDefense > 0 ? heroInfo.spellAttack - monster.spellDefense : 0;
        // 英雄吸血
        int heroBloodSuck = (int)(monsterPhysicalDemage * heroInfo.physicBloodSuck + monsterSpellDemage * heroInfo.spellBloodSuck);
        // 怪物伤害返还系数
        int monsterRevert = (int)(monsterPhysicalDemage * monsterInfo.physicalDemageRevert + monsterSpellDemage * monsterInfo.spellDemageRevert);

        // 魔物打英雄伤害
        int heroPhysicalDemage = monsterInfo.physicalAttack - hero.physicalDefense > 0 ? monsterInfo.physicalAttack - hero.physicalDefense : 0;
        int heroSpellDemage = monsterInfo.spellAttack - hero.spellDefense > 0 ? monsterInfo.spellAttack - hero.spellDefense : 0;
        // 怪物吸血
        int monsterBloodSuck = (int)(heroPhysicalDemage * monsterInfo.physicBloodSuck + heroSpellDemage * monsterInfo.spellBloodSuck);
        // 英雄伤害返还 包含了buff部分的strikeBack
        int heroRevert = (int)(heroPhysicalDemage * (heroInfo.physicalDemageRevert + hero.strikeBack/100) + heroSpellDemage * (heroInfo.spellDemageRevert + hero.strikeBack / 100));

        // 计算血量
        int monsterCount = monsterPhysicalDemage + monsterSpellDemage + heroRevert - monsterBloodSuck;
        monster.health -= monsterCount;
  
        if (monster.health <= 0)
        {
            monster.health = 0;
            MonsterDie(monster);
        }
        // 英雄考虑 自己伤害加深 与 自身直接伤害
        int heroCount = (int)((heroPhysicalDemage + heroSpellDemage + heroInfo.selfPhysicalDemage) * (1 + heroInfo.selfInjury) + monsterRevert - heroBloodSuck);
        hero.health -= heroCount;
        if(hero.health <= 0)
        {
            hero.health = 0;
            HeroDie();
        }

        EventManager.GetInstance().logUI.ShowText("英雄收到了" + heroCount + "伤害," + "魔物受到了" + monsterCount + "伤害");

        

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
        // 杀死怪物的buff触发
        BuffArray.GetInstance().KillMonster();
    }
    
}
