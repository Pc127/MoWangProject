using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleCard
{
    // 名称
    public string name;

    // 说明
    public string explaination;

    // 说明
    public bool needDice;

    // 骰子点数
    public int diceIndex;

    public virtual BattleInfo InvokeCard()
    {
        BattleInfo info = new BattleInfo();

        return info;
    }
}
