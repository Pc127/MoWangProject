using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 用来展示log
public class LogUI : MonoBehaviour
{
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        EventManager.GetInstance().logUI = this;
    }

    public void ShowText(string str)
    {
        text.text = str;
    }
}
