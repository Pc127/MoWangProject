using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public Text text;

    private List<string> prologues;

    void Start()
    {
        prologues = new List<string>();
        prologues.Add("居住在克里特镇的少年 瓦瑞安 曾过着平静的生活，直到那天魔物攻入了镇子。");
        prologues.Add("那天鲜血在村庄挥洒，光芒神教的庇护也黯淡了。");
        prologues.Add("魔物掳走了村民，将他们带往了魔物森林的深处。");
        prologues.Add("有一只魔物突然开口，对瓦瑞安说：“想要拯救他们，就来大湖之底吧，因为下达命令的，魔王就居住在那里”");
        prologues.Add("他没听说过有人可以听懂魔物的语言，但是他一定会去，他也别无选择。");

        StartCoroutine(MyPrologue());
    }

    
    IEnumerator MyPrologue()
    {
        foreach(var item in prologues)
        {
            text.text = item;
            yield return new WaitForSeconds(5.2f);
        }

        SceneManager.LoadScene("SceneOne");

    }
}
