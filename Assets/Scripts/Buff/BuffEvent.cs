using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BuffEvent
{
    // 一次buff事件 保存两个buff供选择
    public Buff buffOne;
    public Buff buffTwo;
}


public class BuffEvents
{
    public BuffEvents(int count)
    {
        this.count = count;
        // 创建相应数量的buff
        myBuffs = new BuffEvent[count];
    }

    // 棋盘格数
    int count;

    // 棋盘信息
    public BuffEvent[] myBuffs;
}
