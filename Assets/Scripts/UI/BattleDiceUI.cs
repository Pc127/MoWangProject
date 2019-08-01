using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDiceUI : MonoBehaviour
{
    public GameObject dice;

    public BattleUI battleUI;

    public DiceShow diceShow;

    public Animator animator;

    void Start()
    {
        animator.enabled = false;
    }

    void Update()
    {

    }

    public void ShootDice()
    {
        animator.enabled = true;
        StartCoroutine(ShotDiceCo(1));
        
    }

    IEnumerator ShotDiceCo(float sec)
    {
        yield return new WaitForSeconds(sec);

        // 关闭动画
        animator.enabled = false;

        // 生成随机数
        int index = Random.Range(1, 7);

        BuffArray.GetInstance().Dice(index);

        EventManager.GetInstance().logUI.ShowText("你掷出了" + index);

        // 掷骰子提示
        diceShow.ShotDice(index);

        battleUI.ShotDice(index);

    }

    // 隐藏移动的骰子
    public void HideBattleDice()
    {
        dice.SetActive(false);
    }

    // 显示移动的骰子
    public void ShowBattleDice()
    {
        dice.SetActive(true);
    }
}
