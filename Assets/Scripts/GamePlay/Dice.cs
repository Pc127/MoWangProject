using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public GameObject moveDice;


    public Animator animator;

    public DiceShow showLog;

    void Start()
    {
        GamePlay.GetInstance().dice = this;
        animator.enabled = false;
    }

    void Update()
    {
        
    }

    public void ShootDice()
    {
        animator.enabled = true;
        StartCoroutine(ShotDiceCo(0.8f));
    }

    IEnumerator ShotDiceCo(float sec)
    {
        yield return new WaitForSeconds(sec);

        // 关闭动画
        animator.enabled = false;

        ActionPoint.GetInstance().point -= 1;
        // 生成随机数
        int index = Random.Range(1, 7);
        Debug.Log("Dice" + index);

        BuffArray.GetInstance().Dice(index);

        EventManager.GetInstance().logUI.ShowText("你掷出了" + index);

        // 掷骰子提示
        showLog.ShotDice(index);

        GamePlay.GetInstance().MakeMove(index);
    }


    // 隐藏移动的骰子
    public void HideMoveDice()
    {
        moveDice.SetActive(false);
    }

    // 显示移动的骰子
    public void ShowMoveDice()
    {
        moveDice.SetActive(true);
    }
}
