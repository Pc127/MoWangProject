using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BleakDog : Monster
{
    public BleakDog()
    {
        this.physicalAttack = 20;
        this.physicalDefense = 5;
        this.spellAttack = 0;
        this.spellDefense = 5;
        this.health = 50;

        this.name = "黑教之犬";
        this.explaination = "凶猛的恶兽";
        this.story = "黑教把死者的血注入到狗的身体中，并施以黑魔法创造了黑教之犬，它头上长着羊角一样的东西，背上布满眼睛和鬃毛。黑教之犬攻击欲望极强并且数量繁多，它们经常入侵到城镇之中，不分昼夜，教会骑士们虽然早就熟练于对抗它们但是依旧对其头疼不已";
    }

    public override BattleInfo MakeAttack()
    {
        BattleInfo info = new BattleInfo();
        info.physicalAttack = this.physicalAttack;
        Debug.Log("黑教之犬攻击");

        this.physicalAttack += 10;
        return info; 
    }
}
