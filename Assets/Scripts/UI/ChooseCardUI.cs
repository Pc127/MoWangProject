using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCardUI : MonoBehaviour
{
    public GameObject show;

    public BattleCardUI first;

    public BattleCardUI second;

    public GameObject preshow;

    void Start()
    {
        EventManager.GetInstance().chooseCardUI = this;
    }

    public void MakeCardChoose(BattleCard f, BattleCard s)
    {
        preshow.SetActive(true);

        StartCoroutine(MakeCardChooseCo(1.2f, f, s));
    }

    IEnumerator MakeCardChooseCo(float sec, BattleCard f, BattleCard s)
    {
        yield return new WaitForSeconds(sec);
        this.show.SetActive(true);
        preshow.SetActive(false);
        first.InitialCard(f, 0, false);
        second.InitialCard(s, 0, false);
    }


}
