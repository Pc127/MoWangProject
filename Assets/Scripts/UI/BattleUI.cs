using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    // 显示相关
    public GameObject show;

    // 怪物信息相关
    public Image monsterImg;

    public Text monsterText;

    public Text monsterName;

    // 怪物属性相关
    public Text physicalAttack;

    public Text physicalDefense;

    public Text spellAttack;

    public Text spellDefense;

    public Text health;

    // 战斗卡牌的父级对象
    public GameObject battleCardShow;

    // 战斗卡牌的perfab
    public GameObject battleCardPerfab;

    // 使用的卡牌
    public BattleCard currentCard;

    // 战斗的怪物
    private Monster myMonster;

    //骰子
    public GameObject dice;
    public Text diceCardName;

    // 更新怪物信息的协程
    private Coroutine infoCoroutine;

    void Start()
    {
        EventManager.GetInstance().battleUI = this;
    }


    public void BattleVsMonster(Monster monster)
    {
        // 显示战斗场景
        show.SetActive(true);

        // 保存怪物
        myMonster = monster;

        this.infoCoroutine = StartCoroutine(InfoPreFrame());

        // 展示卡牌
        ShowBattleCards();
    }

    // 展示卡牌
    public void ShowBattleCards()
    {
        battleCardShow.SetActive(true);

        int index = 0;
        // 删除所有子节点
        foreach (Transform child in battleCardShow.transform)
        {
            if (index == 0)
            {
                index = 10;
            }
            else
                Destroy(child.gameObject);
        }

        index = 0;

        // 读取卡牌序列 并显示
        foreach (BattleCard bc in BattleCardArray.GetInstance().myCards)
        {
            // 初始化卡牌
            GameObject obj = Instantiate(battleCardPerfab);
            obj.transform.parent = battleCardShow.transform;
            BattleCardUI bu = obj.GetComponent<BattleCardUI>();
            bu.InitialCard(bc, index);
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(1, 1, 1);
            obj.gameObject.transform.localPosition = new Vector3(index * 300, 0, 0);
            Debug.Log("加载一张卡牌");
            ++index;
        }
    }

    // 开始进行战斗骰子的判定
    public void StartDice()
    {
        dice.SetActive(true);
    }

    public void ShotDice(int index)
    {
        // 保存
        currentCard.diceIndex = index;

        dice.SetActive(false);
        // 进行战斗
        StartBattle();
    }


    public void StartBattle()
    {
        Battle.StartBattle(myMonster, currentCard);
        // 2s后结束游戏
        if (!myMonster.live)
            EndBattle();
    }

    public void EndBattle()
    {
        // 2秒后结束游戏
        StartCoroutine(EndBattleCoroutine(2));
    }

    // 结束战斗
    IEnumerator EndBattleCoroutine(float sec)
    {
        yield return new WaitForSeconds(sec);

        this.show.SetActive(false);
        GamePlay.GetInstance().ShowMoveDice();
        StopCoroutine(this.infoCoroutine);
    }

    IEnumerator InfoPreFrame()
    {
        while (true)
        {
            // 显示怪物名称 与 说明
            monsterImg.sprite = Resources.Load<Sprite>("Monster/" + myMonster.name);
            monsterName.text = myMonster.name;
            monsterText.text = myMonster.explaination;

            // 更新数值显示
            physicalAttack.text = "" + myMonster.physicalAttack;
            spellAttack.text = "" + myMonster.spellAttack;
            spellDefense.text = "" + myMonster.spellDefense;
            physicalDefense.text = "" + myMonster.physicalDefense;
            health.text = "" + myMonster.health;

            yield return new WaitForEndOfFrame();
        }
    }

    public void UseCard(BattleCard bc)
    {
        // 当前使用的卡牌
        this.currentCard = bc;

        if (bc.needDice)
        {
            StartDice();
        }
        else
        {
            StartBattle();
        }
    }
}
