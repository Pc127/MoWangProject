using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
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

        GamePlay.GetInstance().MakeMove(index);
    }
}
