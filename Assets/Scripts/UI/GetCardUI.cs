using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCardUI : MonoBehaviour
{
    // 获得卡牌的文本说明
    // public Text text;

    // 显示
    public GameObject show;

    // 卡牌图标
    public Image image;

    // 卡牌名称
    public Text cardName;

    // 解释文本
    public Text explaination;

    // 按钮
    public Button button;

    public Text story;

    // 战斗牌
    private BattleCard mycard;

    void Start()
    {
        EventManager.GetInstance().getCardUI = this;
    }

    public void InitialCard(BattleCard bc)
    {
        this.show.SetActive(true);
        this.mycard = bc;
        // 绑定点击事件
        this.button.onClick.AddListener(OnClick);

        this.image.sprite = Resources.Load<Sprite>("BattleCard/" + mycard.name);

        this.cardName.text = mycard.name;
        this.explaination.text = mycard.explaination;
        this.story.text = bc.story;
    }

    public void OnClick()
    {
        this.show.SetActive(false);
    }
}
