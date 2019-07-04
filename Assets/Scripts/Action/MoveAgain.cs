using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAgain : Action
{
    public MoveAgain()
    {
        this.name = "再移动牌";
        this.fuction = "在行动阶段，可以再进行指定距离的移动";
        this.explaination = "捕食者要比猎物行动更快";
    }

    public override ActionInfo InvokeAction()
    {
        ActionInfo info = new ActionInfo();
        info.move = true;
        return info;
    }
}
