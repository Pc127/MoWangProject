using System.Collections;
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
        // 生成随机数
        int index = Random.Range(1, 7);

        Debug.Log("Dice" + index);

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
