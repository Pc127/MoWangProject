using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInfo
{
    public bool dodge = false;
    public bool move = false;
    public int moveLen = 0;
}

public class Action
{
    // 当前种类的牌数量
    public int count;

    // 当前种类的activ
    public int activeCount;

    public string name;

    public string explaination;

    public string fuction;

    public virtual ActionInfo InvokeAction()
    {
        return new ActionInfo();
    }
}
