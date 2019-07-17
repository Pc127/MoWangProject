using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCardUI : MonoBehaviour
{
    public Image image;

    // 卡牌名称
    public Text cardName;

    // 解释文本
    public Text explaination;

    public Button button;

    // 在manager中的数字索引
    public int cardIndex;

    private BattleCard mycard;

    public void InitialCard(BattleCard bc, int index)
    {
        this.mycard = bc;
        this.cardIndex = index;
        this.button.onClick.AddListener(OnChoose);

        this.image.sprite = Resources.Load<Sprite>("BattleCard/" + mycard.name);

        this.cardName.text = mycard.name;
        this.explaination.text = mycard.explaination;
    }

    public void OnChoose()
    {
        Debug.Log("出牌" + mycard.name);
        EventManager.GetInstance().battleUI.UseCard(mycard);
        // 卡牌已出
        this.gameObject.SetActive(false);
    }
}
