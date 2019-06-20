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
    }
}
