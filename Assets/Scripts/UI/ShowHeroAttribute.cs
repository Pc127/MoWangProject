using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHeroAttribute : MonoBehaviour
{
    public Text physicalAttack;

    public Text physicalDefense;

    public Text spellAttack;

    public Text spellDefense;

    public Text health;

    public Text actionPoint;

    public Text monsterCount;

    public Text maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 更新数值
        UpdateInfo();
    }

    void UpdateInfo()
    {
        Hero hero = Hero.GetInstance();

        // 更新数值显示
        physicalAttack.text = ""+ hero.physicalAttack;

        spellAttack.text = "" + hero.spellAttack;

        spellDefense.text = "" + hero.spellDefense;

        physicalDefense.text = "" + hero.physicalDefense;

        health.text = "" + hero.health;

        maxHealth.text = "" + hero.healthMax;

        actionPoint.text = "行动点数： " + ActionPoint.GetInstance().point + " ";

        int i = 0;
        foreach (var item in GamePersist.GetInstance().GetMonsterEvents().myMonsters)
        {
            if (item.monster.live)
                i++;
        }

        monsterCount.text = "剩余怪物： " + i + "";
    }
}
