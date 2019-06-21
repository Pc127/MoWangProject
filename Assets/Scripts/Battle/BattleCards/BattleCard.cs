using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BattleCard
{
    // 名称
    public string name;

    // 说明
    public string explaination;

    public virtual BattleInfo InvokeCard()
    {
        BattleInfo info = new BattleInfo();

        return info;
    }
}
