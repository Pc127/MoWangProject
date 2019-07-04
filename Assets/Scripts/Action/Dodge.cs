using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : Action
{
    public Dodge()
    {
        this.name = "闪避牌";
        this.fuction = "在行动阶段，可以使用闪避牌闪避怪物的攻击";
        this.explaination = "不是每次流血都有意义";
    }

    // 返回一个闪避信息
    public override ActionInfo InvokeAction()
    {
        ActionInfo info = new ActionInfo();
        info.dodge = true;
        return info;
    }
}
