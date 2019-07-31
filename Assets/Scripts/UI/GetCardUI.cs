using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCardUI : MonoBehaviour
{
    // 获得卡牌的文本说明
    // public Text text;

    // 显示
    public GameObject node;

    public GameObject show;

    public GameObject battleCardPerfab;

    void Start()
    {
        EventManager.GetInstance().getCardUI = this;
    }

    public void InitialCard(BattleCard[] bcs)
    {
        this.show.SetActive(true);

        this.node.SetActive(true);

        float index = - (bcs.Length -1 )*1.0f/2f;

        foreach(var bc in bcs)
        {
            // 初始化卡牌
            GameObject obj = Instantiate(battleCardPerfab);
            obj.transform.parent = node.transform;
            BattleCardUI bu = obj.GetComponent<BattleCardUI>();
            // 可以使用的卡牌

            bu.InitialGetCard(bc);
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(0.7f, 0.7f, 1);

            obj.gameObject.transform.localPosition = new Vector3(index * 300, 0, 0);

            index+=1;
        }
        
    }

    public void OnClick()
    {
        this.show.SetActive(false);
    }
}
