using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEndOne : MonoBehaviour
{
    public Text text;

    private List<string> badend;

    void Start()
    {
        badend = new List<string>();
        badend.Add("你战败了，喧闹的魔物拖着你奄奄一息的身体，进入了魔物森林的深处。");
        badend.Add("你被丢入了森林深处的蓝色湖泊里。");
        badend.Add("不断的下坠。。下坠。。");
        badend.Add("你恰巧落在了一副黑色的棺材上");
        badend.Add("你似乎听见了棺材打开的声音，你的心脏猛烈得跳动了一下，然后永远失去了意识");

        StartCoroutine(MyBadend());
    }


    IEnumerator MyBadend()
    {
        foreach (var item in badend)
        {
            text.text = item;
            yield return new WaitForSeconds(5.2f);
        }

        SceneManager.LoadScene("Menu");

    }
}
