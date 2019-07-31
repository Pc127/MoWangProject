using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist
{
    // 私有构造函数
    private GamePersist()
    {
        currentLevel = 0;
        this.chessBoards = new ChessBoard[3];

        // 初始化 第一个棋盘
        this.chessBoards[0] = new ChessBoard(60);
        this.chessBoards[0].Build(new Vector2(0, 0), 150, 75, 16, 16);

        this.chessBoards[1] = new ChessBoard(60);
        this.chessBoards[1].Build(new Vector2(0, 0), 150, 75, 16, 16);

        // 初始化buff
        InitBuff();

        // 初始化怪物
        InitMonsters();

        // 初始化卡牌
        InitBattleCard();

    }

    // 单例类
    private static GamePersist instance = null;

    // 单例获取函数
    public static GamePersist GetInstance()
    {
        if (instance == null)
            instance = new GamePersist();

        return instance;
    }

    // 获取当前棋盘
    public ChessBoard GetChessBoard()
    {
        return this.chessBoards[this.currentLevel];
    }

    // 获取当前buff事件
    public BuffEventMap GetBuffEvents()
    {
        return sceneBuffEvents[this.currentLevel];
    }

    // 获得当前monster事件
    public MonsterEventMap GetMonsterEvents()
    {
        return sceneMonster[this.currentLevel];
    }

    // 获取当前卡牌获取事件
    public BattleCardMap GetBattleCardMap()
    {
        return sceneBattleCard[this.currentLevel];
    }

    // 保存三个棋盘
    public ChessBoard[] chessBoards;
    // 保存三个buffer棋盘事件
    public BuffEventMap[] sceneBuffEvents;
    // 保存三个monster世界
    public MonsterEventMap[] sceneMonster;
    // 保存三个卡牌获取事件
    public BattleCardMap[] sceneBattleCard;

    public int currentLevel;

    // 第一关的怪物遮挡
    // 8 4 3的累加
    public int[] levelOneCull = new int[3] { 8,12,15};


    private void InitMonsters()
    {
        // 怪物事件
        // 数组
        this.sceneMonster = new MonsterEventMap[3];
        // 第一个场景有21只怪物
        this.sceneMonster[0] = new MonsterEventMap(16);

        MonsterEvent monsterEvent = new MonsterEvent(1, 2);
        Monster monster = new BleakDog();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[0] = monsterEvent;

        monsterEvent = new MonsterEvent(4, 6);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[1] = monsterEvent;

        monsterEvent = new MonsterEvent(8, 9);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[2] = monsterEvent;

        monsterEvent = new MonsterEvent(11, 15);
        monster = new OctopusMan();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[3] = monsterEvent;

        monsterEvent = new MonsterEvent(17, 18);
        monster = new BleakDog();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[4] = monsterEvent;

        monsterEvent = new MonsterEvent(20, 22);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[5] = monsterEvent;

        monsterEvent = new MonsterEvent(24, 26);
        monster = new BleakGhost();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[6] = monsterEvent;

        monsterEvent = new MonsterEvent(28, 29);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[7] = monsterEvent;

        monsterEvent = new MonsterEvent(31, 35);
        monster = new SneakMan();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[8] = monsterEvent;

        monsterEvent = new MonsterEvent(37, 38);
        monster = new BleakDog();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[9] = monsterEvent;

        monsterEvent = new MonsterEvent(40, 42);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[10] = monsterEvent;

        monsterEvent = new MonsterEvent(44, 45);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[11] = monsterEvent;

        monsterEvent = new MonsterEvent(47, 49);
        monster = new BleakGhost();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[12] = monsterEvent;

        monsterEvent = new MonsterEvent(51, 52);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[13] = monsterEvent;

        monsterEvent = new MonsterEvent(54, 59);
        monster = new ArmBrokenKnight();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[14] = monsterEvent;

        monsterEvent = new MonsterEvent(60, 60);
        monster = new BlackBarrier();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[15] = monsterEvent;
    }

    private void InitBattleCard()
    {
        // 初始卡牌
        // 卡牌加入一张跳劈卡
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());

        this.sceneBattleCard = new BattleCardMap[3];
        BattleCardMap levelOne = new BattleCardMap(60);
        this.sceneBattleCard[0] = levelOne;

        BattleCardEvent cardEvent;
        cardEvent = new BattleCardEvent
        {
            one = new Fireball(),
            two = new JumpCut()
        };
        this.sceneBattleCard[0].myCardEvent[11] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[12] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[13] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[15] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[16] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[17] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[29] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[51] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[52] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[53] = cardEvent;

        cardEvent = new BattleCardEvent
        {
            one = new DodgeCard(),
            two = new Recovery()
        };
        this.sceneBattleCard[0].myCardEvent[18] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[20] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[21] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[22] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[23] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[24] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[25] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[26] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[27] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[28] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[31] = cardEvent;

        cardEvent = new BattleCardEvent
        {
            one = new DoubleEdgeSword(),
            two = new DodgeCard()
        };
        this.sceneBattleCard[0].myCardEvent[40] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[41] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[42] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[43] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[44] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[45] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[46] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[54] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[55] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[56] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[57] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[58] = cardEvent;
        this.sceneBattleCard[0].myCardEvent[59] = cardEvent;

        // 全部卡牌事件都变成 火球 跳劈
        // i代表格数


    }

    private void InitBuff()
    {
        // buff事件初始化
        this.sceneBuffEvents = new BuffEventMap[3];
        // 初始化 第一个棋盘上的buff事件

        BuffEventMap levelOne = new BuffEventMap(60);
        this.sceneBuffEvents[0] = levelOne;

        BuffEvent be1 = new BuffEvent
        {
            buffOne = new BattleMemory(5),
            buffTwo = new ElementPerception(5)
        };

        levelOne.myBuffs[1] = be1;
        levelOne.myBuffs[2] = be1;
        levelOne.myBuffs[7] = be1;
        levelOne.myBuffs[48] = be1;

        be1 = new BuffEvent
        {
            buffOne = new DodgeAwareness(5),
            buffTwo = new ShieldOfSoul(5)
        };
        levelOne.myBuffs[3] = be1;
        levelOne.myBuffs[8] = be1;
        levelOne.myBuffs[9] = be1;
        levelOne.myBuffs[50] = be1;

        be1 = new BuffEvent
        {
            buffOne = new Coalescence(2),
            buffTwo = new Harvest(5)
        };
        levelOne.myBuffs[5] = be1;
        levelOne.myBuffs[10] = be1;

        be1 = new BuffEvent
        {
            buffOne = new SoulOfMonster(2),
            buffTwo = new LuckTouch(5)
        };
        levelOne.myBuffs[30] = be1;
        levelOne.myBuffs[33] = be1;
        levelOne.myBuffs[36] = be1;

        be1 = new BuffEvent
        {
            buffOne = new PrickyArmour(10),
            buffTwo = new LuckTouch(5)
        };
        levelOne.myBuffs[34] = be1;
        levelOne.myBuffs[35] = be1;
        levelOne.myBuffs[38] = be1;

    }
}
