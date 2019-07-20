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

    public string story;

    // 叠毒
    private int toxin;

    private float latentDamage;

    public Monster()
    {
        live = true;
        toxin = 0;
        latentDamage = 0.5f;
    }

    public virtual BattleInfo MakeAttack()
    {
        return new BattleInfo();
    }

    // 死亡事件 为玩家带来一张牌
    public virtual void Die()
    {
        BattleCard bc = BattleCardFactory.GetInstance().GetRandomCard();
        EventManager.GetInstance().getCardUI.InitialCard(bc);
        BattleCardArray.GetInstance().myCards.Add(bc);
    }

    public void UseToxin()
    {
        if(++toxin == 3)
        {
            toxin = 0;
            this.health -= 1000 - this.spellDefense;
        }
    }

    public int UseLatentDamage()
    {
        this.latentDamage *= 2;

        return (int)this.latentDamage;
    }

    // 判断是否存活
    public bool live;

}
