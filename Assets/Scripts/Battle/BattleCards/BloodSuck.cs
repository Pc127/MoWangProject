using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSuck : BattleCard
{
    public BloodSuck()
    {
        this.name = "舔血";
        this.explaination = "进行一次物理攻击，并回复造成伤害数值的血量（物理攻击*1）";
        this.needDice = false;
        this.diceIndex = 0;
        this.attackType = 0;

        this.story = "异教徒的格斗技，光明教会的骑士们向来不屑使用，灵魂以鲜血为媒介，舔舐鲜血能够获得灵魂的力量，回复自身的血量，这个格斗技似乎令人上瘾并将人导向深渊。";
    }

    public override BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        info.physicBloodSuck = 1;
        info.physicalAttack = Hero.GetInstance().physicalAttack;
        return info;
    }
}