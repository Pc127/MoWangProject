using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NormalEnd : MonoBehaviour
{
    public Text text;

    private List<string> badend;

    void Start()
    {
        badend = new List<string>();
        badend.Add("魔王迪蒙的身躯开始变得灰暗，慢慢得孵化为了尘土");
        badend.Add("你击败了那不可一世的魔王");
        badend.Add("甚至你觉得一股力量从体内涌现，一股强大而纯粹的力量，你觉得连“光照术”也不能比它更纯粹了");
        badend.Add("“这就是魔王的力量吗？”你自言自语道");
        badend.Add("你皱了皱眉头觉得有些不对劲，但这种怪异的感觉转瞬即逝");
        badend.Add("你难以抑制得仰头大笑，周身的魔物不知为何地向你低下了头颅");

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
