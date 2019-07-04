using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDiceUI : MonoBehaviour
{
    public GameObject dice;

    public BattleUI battleUI;

    void Start()
    {
    }

    void Update()
    {

    }

    public void ShootDice()
    {
        // 生成随机数
        int index = Random.Range(1, 7);

        Debug.Log("Dice" + index);

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
