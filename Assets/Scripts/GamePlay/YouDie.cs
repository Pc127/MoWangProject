using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDie : MonoBehaviour
{
    public GameObject show;

    private int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        GamePlay.GetInstance().die = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActionPoint.GetInstance().point < 0)
            HeroDie();
    }

    public void HeroDie()
    {
        this.currentLevel = GamePersist.GetInstance().currentLevel;
        this.show.SetActive(true);
        // 游戏失败 几秒后返回主菜单
        StartCoroutine(HeroDieCo());
    }

    IEnumerator HeroDieCo()
    {
        yield return new WaitForSeconds(3.0f);
        if (currentLevel == 0)
            SceneManager.LoadScene("BadEndOne");
        else if (currentLevel == 2)
            SceneManager.LoadScene("BadEndTwo");      
    }
}
