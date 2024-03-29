﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero
{
    // 私有构造函数
    private Hero()
    {
        healthMax = 100;
        health = 100;
        
        spellAttack = 10;
        spellDefense = 10;
        physicalAttack = 20;
        physicalDefense = 10;

        bloodCeremony = false;
        gloryBlessing = false;

        GamePersist.GetInstance();
    }

    // 单例类
    private static Hero instance = null;

    // 单例获取函数
    public static Hero GetInstance()
    {
        if (instance == null)
            instance = new Hero();

        return instance;
    }

    // 物理攻击
    public int physicalAttack;

    // 魔法攻击
    public int spellAttack;

    // 物理防御
    public int physicalDefense;

    // 魔法防御
    public int spellDefense;

    private int m_health;
    // 血量
    public int health {
        get
        {
            return m_health;
        }

        set
        {
            if (value > healthMax)
                m_health = healthMax;
            else
                m_health = value;
        }
    }

    // 反击 包括物理与魔法反击
    public int strikeBack;

    public bool bloodCeremony;

    public bool gloryBlessing;

    public int healthMax;
}
