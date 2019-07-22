using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleCard
{
    // 名称
    public string name;

    // 说明
    public string explaination;

    // 故事
    public string story;

    // 说明
    public bool needDice;

    // 骰子点数
    public int diceIndex;

    // 活跃状态
    public bool active = true;

    public virtual BattleInfo InvokeCard(Monster monster)
    {
        BattleInfo info = new BattleInfo();

        return info;
    }

    public virtual BattleCard Clone()
    {
        return MemberwiseClone() as BattleCard;
    }
}
