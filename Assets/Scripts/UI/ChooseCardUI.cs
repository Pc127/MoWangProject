using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCardUI : MonoBehaviour
{
    public GameObject show;

    public BattleCardUI first;

    public BattleCardUI second;

    void Start()
    {
        EventManager.GetInstance().chooseCardUI = this;
    }

    public void MakeCardChoose(BattleCard f, BattleCard s)
    {
        this.show.SetActive(true);

        first.InitialCard(f, 0, false);
        second.InitialCard(s, 0, false);
    }


}
