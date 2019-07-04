using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionCardUI : MonoBehaviour
{
    public Image image;

    // 卡牌名称
    public Text cardName;

    // 卡牌功能
    public Text fuction;
    
    // 解释文本
    public Text explaination;

    // 是否可以使用
    public GameObject mark;

    // 出牌按钮
    public Button button;

    // 进行再移动的显示
    public GameObject moveAgainShow;

    // 进行再移动的按钮
    public List<Button> moveIndex;

    // 显示可用数量
    public Text totalCount;
    public Text availCount;

    // 保存当前行动牌
    private Action myAction;

    public void InitialCard(Action action, bool canBeUse)
    {
        this.myAction = action;
        this.button.onClick.AddListener(OnChoose);

        this.image.sprite = Resources.Load<Sprite>("ActionCard/" + myAction.name);

        this.cardName.text = myAction.name;
        this.explaination.text = myAction.explaination;
        this.fuction.text = myAction.fuction;
        this.totalCount.text = myAction.count + "";
        this.availCount.text = myAction.activeCount + "";

        // 检查是否可用
        if (canBeUse && myAction.activeCount != 0)
        {
            this.mark.SetActive(false);
            this.button.onClick.AddListener(OnChoose);
        }
        else
        {
            this.mark.SetActive(true);
            this.button.onClick.RemoveAllListeners();
        }
    }

    public void OnChoose()
    {
        // 消耗牌
        ActionCardArray.GetInstance().UseActionCard(this.myAction.name);

        Debug.Log("使用卡牌" + this.myAction.name);

        if(myAction.name == "闪避牌")
        {
            DodgeChoose();
        }
        else if(myAction.name == "再移动牌")
        {
            MoveAgainChoose();
        }
    }

    public void DodgeChoose()
    {
        // 激活闪避
        EventManager.GetInstance().InvokeAction(this.myAction.InvokeAction());
    }

    public void MoveAgainChoose()
    {
        this.moveAgainShow.SetActive(true);
    }

    public void MoveIndex(int index)
    {
        ActionInfo info = myAction.InvokeAction();
        info.moveLen = index;
        // 激活移动
        EventManager.GetInstance().InvokeAction(info);
    }

}

