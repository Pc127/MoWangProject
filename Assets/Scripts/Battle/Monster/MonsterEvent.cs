using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEvent
{
    // 怪物事件的范围
    public MonsterEvent(int begin, int end)
    {
        this.begin = begin;
        this.end = end;
    }

    public int begin;
    public int end;

    // 当前
    public int current = 0;

    public Monster monster;
}

public class MonsterEvents
{
    public MonsterEvents(int count)
    {
        this.count = count;
        // 创建相应数量的buff
        this.myMonsters = new MonsterEvent[count];
    }

    // 怪物数量数
    int count;

    public Monster GetMonster(int index)
    {
        foreach(MonsterEvent me in myMonsters)
        {
            // 当前怪物
            if (me.current == index)
                return me.monster;

            if(me.current == 0)
            {
                if((index >= me.begin) && (index <= me.end))
                {
                    // 在范围中找到了这个怪物
                    me.current = index;
                    return me.monster;
                }
            }
        }

        // 并没有找到想要的
        return null;
    }

    public MonsterEvent[] myMonsters;

}
