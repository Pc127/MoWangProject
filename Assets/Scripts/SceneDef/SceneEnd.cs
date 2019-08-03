﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnd : MonoBehaviour
{
    private bool start = true;
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            Hero.GetInstance().health = Hero.GetInstance().healthMax;

            GamePersist.GetInstance().currentLevel = 2;
            GamePlay.GetInstance().MakeMove(8);
        }
    }
}
