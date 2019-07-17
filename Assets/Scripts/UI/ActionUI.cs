using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionUI : MonoBehaviour
{
    // 显示相关
    public GameObject show;

    // Action card 的父级对象
    public GameObject actionCardShow;

    // 行动卡牌的perfab
    public GameObject actionCardPerfab;

    void Start()
    {
        // 注册
        //EventManager.GetInstance().actionUI = this;
    }

    void Update()
    {
        
    }

    public void MakeActionChoose(bool meetMonster)
    {
        this.show.SetActive(true);

        // 设置卡牌状态 显示卡牌
        actionCardShow.SetActive(true);

        int index = 0;
        // 删除所有子节点
        foreach (Transform child in actionCardShow.transform)
        {
            if (index == 0)
            {
                index = 10;
            }
            else
                Destroy(child.gameObject);
        }

        index = 0;

        Debug.Log("行动牌数量" + ActionCardArray.GetInstance().myActions.Count);

        // 读取卡牌序列 并显示
        foreach (var item in ActionCardArray.GetInstance().myActions)
        {
            Debug.Log("加载一张行动牌");
            // 初始化卡牌
            GameObject obj = Instantiate(actionCardPerfab);
            obj.transform.parent = actionCardShow.transform;
            ActionCardUI ac = obj.GetComponent<ActionCardUI>();

            // 判断卡牌是否可以使用
            if(item.Value.name == "闪避牌")
            {
                if (meetMonster)
                    ac.InitialCard(item.Value, true);
                else
                    ac.InitialCard(item.Value, false);
            }
            else
            {
                ac.InitialCard(item.Value, true);
            }
            
            // 卡牌位置
            obj.SetActive(true);
            obj.gameObject.transform.localPosition = new Vector3(index * 500, 0, 0);
            obj.transform.localScale = new Vector3(1, 1, 1);
            ++index;
        }
    }

    // 隐藏action阶段
    public void HideAction()
    {
        this.show.SetActive(false);
    }

    public void QuitAction()
    {
        HideAction();
        EventManager.GetInstance().InvokeEvent();
    }
}
