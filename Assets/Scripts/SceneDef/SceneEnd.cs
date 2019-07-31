using System.Collections;
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

            GamePersist.GetInstance().currentLevel = 2;
            GamePlay.GetInstance().MakeMove(9);
        }
    }
}
