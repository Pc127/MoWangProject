using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCardEvent
{
    // 一次buff事件 保存两个buff供选择
    public BattleCard one;
    public BattleCard two;
}


public class BattleCardMap
{
    public BattleCardMap(int count)
    {
        this.count = count;
        // 创建相应数量的buff
        myCardEvent = new BattleCardEvent[count];
    }

    // 棋盘格数
    int count;

    // 棋盘信息 每格的buff等级
    public BattleCardEvent[] myCardEvent;

    // 获取棋盘上的随机Buff
    public BattleCardEvent GetBattleCardEvent(int index)
    {
        // 注意对象的拷贝
        BattleCardEvent be = myCardEvent[index];
        if( be == null)
            return be;

        BattleCardEvent re = new BattleCardEvent
        {
            one = be.one.Clone(),
            two = be.two.Clone()
        };

        return re;
    }
}