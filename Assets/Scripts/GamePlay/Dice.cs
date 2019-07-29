﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject moveDice;

    void Start()
    {
        GamePlay.GetInstance().dice = this;
    }

    void Update()
    {
        
    }

    public void ShootDice()
    {
        ActionPoint.GetInstance().point -= 1;
        // 生成随机数
        int index = Random.Range(1, 7);

        Debug.Log("Dice" + index);

        // dice buff
        BuffArray.GetInstance().Dice(index);

        EventManager.GetInstance().logUI.ShowText("你掷出了" + index);

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
