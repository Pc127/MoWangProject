using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GamePlay.GetInstance().die = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HeroDie()
    {
        // 游戏失败 几秒后返回主菜单
    }
}
