using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadEndTwo : MonoBehaviour
{
    public Text text;

    private List<string> badend;

    void Start()
    {
        badend = new List<string>();
        badend.Add("魔王迪蒙的强大超出了你想象");
        badend.Add("他的力量黑暗得如此纯粹，如同光芒神教的“光照术”一般");
        badend.Add("奄奄一息的你被魔王举起，你看到了魔王混沌的双眼");
        badend.Add("忽然有一股力量从魔王的手臂肆意到你的体内，你的意识还想挣扎，但你永远得失去了它");

        StartCoroutine(MyBadend());
    }


    IEnumerator MyBadend()
    {
        foreach (var item in badend)
        {
            text.text = item;
            yield return new WaitForSeconds(5.2f);
        }

        SceneManager.LoadScene("SceneOne");

    }
}
