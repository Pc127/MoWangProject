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
    public Text monsterStroy;

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

    // 上次使用的卡牌 用来作为 空白符咒的逻辑
    public BattleCard lastCard;
    // 使用的卡牌
    public BattleCard currentCard;

    // 战斗的怪物
    private Monster myMonster;

    // 再进行一次移动的Ui
    public GameObject moveAgainShow;

    //骰子
    public GameObject dice;
    public Text diceCardName;

    // 更新怪物信息的协程
    private Coroutine infoCoroutine;

    public GameObject runAway;

    public GameObject preshow;

    // 战斗数值显示
    public GameObject battleCount;
    public Text heroCount;
    public Text monsterCount;

    public List<GameObject> needHide;


    // 卡牌间距
    private int cardInterval = 220;
    private int cardCount;

    // 500*500
    public RectTransform monsterRect;

    void Start()
    {
        EventManager.GetInstance().battleUI = this;
    }


    public void BattleVsMonster(Monster monster)
    {
        
        battleCount.SetActive(false);
        preshow.SetActive(true);
        // 保存怪物
        myMonster = monster;

        EventManager.GetInstance().logUI.ShowText("遭遇了魔物" + myMonster.name);

        StartCoroutine(BattleWithMonsterCo(1.2f));
    }

    IEnumerator BattleWithMonsterCo(float sec)
    {
        yield return new WaitForSeconds(sec);
        foreach (var item in needHide)
        {
            item.SetActive(false);
        }

        // 逃跑选项
        //runAway.SetActive(true);
        this.show.SetActive(true);
        this.preshow.SetActive(false);

        this.infoCoroutine = StartCoroutine(InfoPreFrame());
        // 展示卡牌
        ShowBattleCards();
    }

    // 展示卡牌
    public void ShowBattleCards()
    {
        battleCardShow.SetActive(true);

        int index = 0;
        cardCount = 0;
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

        bool cull = false;
        if (myMonster.name == "魔王迪蒙")
            cull = true;

        index = 0;
        this.battleCardShow.transform.localPosition = new Vector3(0, 0, 0);

        // 读取卡牌序列 并显示
        foreach (BattleCard bc in BattleCardArray.GetInstance().myCards)
        {
            // 冷却的卡牌不参与展示
            if (bc.active == false)
                continue;
            // 不能对魔王使用闪避
            if (cull)
            {
                if (bc.name == "烟雾弹" || bc.name == "再次移动")
                    continue;
            }
            // 初始化卡牌
            GameObject obj = Instantiate(battleCardPerfab);
            obj.transform.parent = battleCardShow.transform;
            BattleCardUI bu = obj.GetComponent<BattleCardUI>();
            // 可以使用的卡牌
            bu.InitialCard(bc, index, true);
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(0.7f, 0.7f, 1);
            obj.gameObject.transform.localPosition = new Vector3(index * cardInterval - 700, -410, 0);
            Debug.Log("加载一张卡牌");
            ++index;
            cardCount++;
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

    // 逃跑会受到伤害
    public void RunAway()
    {
        Battle.StartBattle(myMonster, new RunAway());
        // 2s后结束游戏
        EndBattle();
    }

    // 闪避不会收到伤害
    public void Dodge()
    {
        EndBattle();
    }

    // 再移动
    public void ShowMoveAgain()
    {
        this.moveAgainShow.SetActive(true);
    }

    public void MoveAgain(int index)
    {
        this.moveAgainShow.SetActive(false);
        StartCoroutine(MoveAgainCoroutine(index, 1.2f));
    }

    public void StartBattle()
    {
        Battle.StartBattle(myMonster, currentCard);
        // 2s后结束游戏
        this.lastCard = currentCard;
        if (!myMonster.live)
            EndBattle();
    }

    // 安全撤离 safe exit
    public void EndBattle()
    {
        // 战斗结束buff触发
        BuffArray.GetInstance().AfterBattle();
        // 2秒后结束游戏
        StartCoroutine(EndBattleCoroutine(1.2F));
    }

    IEnumerator MoveAgainCoroutine(int index, float sec)
    {

        yield return new WaitForSeconds(sec);
        foreach (var item in needHide)
        {
            item.SetActive(true);
        }
        this.show.SetActive(false);
        GamePlay.GetInstance().heroMove.MakeMove(index);
        StopCoroutine(this.infoCoroutine);
    }

    // 结束战斗
    IEnumerator EndBattleCoroutine(float sec)
    {
        yield return new WaitForSeconds(sec);

        foreach (var item in needHide)
        {
            item.SetActive(true);
        }

        this.show.SetActive(false);
        GamePlay.GetInstance().ShowMoveDice();
        StopCoroutine(this.infoCoroutine);
    }

    // 更新怪物信息
    IEnumerator InfoPreFrame()
    {
        while (true)
        {
            // 显示怪物名称 与 说明
            Sprite sp = Resources.Load<Sprite>("Monster/" + myMonster.name);
            monsterImg.sprite = sp;
            if (sp.rect.width > sp.rect.height)
            {
                monsterRect.sizeDelta = new Vector2(500, 500/sp.rect.width*sp.rect.height);
            }
            else
            {
                monsterRect.sizeDelta = new Vector2(500 / sp.rect.height * sp.rect.width, 500);
            }

            if(myMonster.name == "魔王迪蒙")
            {
                monsterRect.sizeDelta = new Vector2(600, 600);
            }

            monsterName.text = myMonster.name;
            monsterText.text = myMonster.explaination;
            monsterStroy.text = myMonster.story;

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

    public void MoveCard(bool forward)
    {
        StartCoroutine(MoveCardCo(forward));
    }

    IEnumerator MoveCardCo(bool forward)
    {
        //if (forward)
            //this.battleCardShow.transform.localPosition.x;
        int distant = 0;
        while(distant!= 300){
            distant += 60;
            if(forward)
                this.battleCardShow.transform.localPosition += new Vector3(60, 0, 0);
            else
                this.battleCardShow.transform.localPosition -= new Vector3(60, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void ShowBattleCount(int hero, int monster)
    {
        Color green = new Color(10f/255, 170f/255, 10f/255);
        Color red = new Color(225f/255, 25f/255, 25f/255);

        battleCount.SetActive(true);

        if(hero>0)
        {
            heroCount.text = "+" + hero;
            heroCount.color = green;
        }
        else
        {
            heroCount.text = hero + "";
            heroCount.color = red;
        }

        if (monster > 0)
        {
            monsterCount.text = "+" + monster;
            monsterCount.color = green;
        }
        else
        {
            monsterCount.text = monster + "";
            monsterCount.color = red;
        }
    }
}
