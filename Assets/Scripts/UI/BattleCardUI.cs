using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleCardUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;

    // 卡牌名称
    public Text cardName;

    // 解释文本
    public Text explaination;

    public Button button;

    public Text stroy;

    public GameObject storyShow;

    // 在manager中的数字索引
    public int cardIndex;

    private BattleCard mycard;

    public void InitialCard(BattleCard bc, int index, bool use)
    {
        this.mycard = bc;
        this.cardIndex = index;
        this.stroy.text = bc.story;
        if (use)
            this.button.onClick.AddListener(OnUse);
        else
            this.button.onClick.AddListener(OnChoose);

        this.image.sprite = Resources.Load<Sprite>("BattleCard/" + mycard.name);

        this.cardName.text = mycard.name;
        this.explaination.text = mycard.explaination;
    }

    public void OnUse()
    {
        this.mycard.active = false;
        Debug.Log("出牌" + mycard.name);
        EventManager.GetInstance().logUI.ShowText("使用了战斗牌" + mycard.name);

        StartCoroutine(UseCard(1.2f));
    }

    public void OnChoose()
    {
        Debug.Log("出牌" + mycard.name);
        EventManager.GetInstance().logUI.ShowText("选择了战斗牌" + mycard.name);

        StartCoroutine(ChooseCard(1.2f));
    }

    IEnumerator UseCard(float sec)
    {

        yield return new WaitForSeconds(sec);

        EventManager.GetInstance().battleUI.UseCard(mycard);
        // 使用完 一张牌以后 更新牌的堆叠顺序
        EventManager.GetInstance().battleUI.ShowBattleCards();
        // 卡牌已出
        this.gameObject.SetActive(false);
        
    }

    IEnumerator ChooseCard(float sec)
    {
        yield return new WaitForSeconds(sec);

        BattleCardArray.GetInstance().myCards.Add(this.mycard);
        // 卡牌已出
        EventManager.GetInstance().chooseCardUI.show.SetActive(false);

        // 进入移动阶段
        GamePlay.GetInstance().ShowMoveDice();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.storyShow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.storyShow.SetActive(false);
    }
}
