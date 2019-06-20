using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUI : MonoBehaviour
{
    // 分别用来加载两个buff 的icon
    public Image sp1;

    public Image sp2;

    // 当前buff 事件
    BuffEvent currentEvent;

    // 保存是否展示ui
    public GameObject show;

    // 两个属性
    public Text attribute1;

    public Text attribute2;

    // 两个说明
    public Text explain1;

    public Text explain2;
    
    void Start()
    {
        EventManager.GetInstance().buffUI = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 获得当前的event
    public void GetBuffEvent(BuffEvent be)
    {
        currentEvent = be;

        // 更新两个纹理
        sp1.sprite = Resources.Load<Sprite>("Buff/" + currentEvent.buffOne.name);
        sp2.sprite = Resources.Load<Sprite>("Buff/" + currentEvent.buffTwo.name);

        attribute1.text = currentEvent.buffOne.attribute;
        attribute2.text = currentEvent.buffTwo.attribute;

        explain1.text = currentEvent.buffOne.explaination;
        explain2.text = currentEvent.buffTwo.explaination;

        // 显示
        show.SetActive(true);
    }

    // 选择事件
    public void ChooseBuff(int index)
    {
        Debug.Log("make a choose");
        if(index == 0)
        {
            BuffArray.GetInstance().AddBuff(currentEvent.buffOne.name, currentEvent.buffOne);
        }
        else if(index == 1)
        {
            BuffArray.GetInstance().AddBuff(currentEvent.buffTwo.name, currentEvent.buffTwo);
        }

        // 隐藏
        show.SetActive(false);

        // 点击完开始 新的掷骰子事件
        GamePlay.GetInstance().ShowMoveDice();
    }

}
