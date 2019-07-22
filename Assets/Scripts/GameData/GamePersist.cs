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


    private void InitMonsters()
    {
        // 怪物事件
        // 数组
        this.sceneMonster = new MonsterEventMap[3];
        // 第一个场景有21只怪物
        this.sceneMonster[0] = new MonsterEventMap(21);

        MonsterEvent monsterEvent = new MonsterEvent(1, 2);
        Monster monster = new BleakDog();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[0] = monsterEvent;

        monsterEvent = new MonsterEvent(4, 4);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[1] = monsterEvent;

        monsterEvent = new MonsterEvent(6, 6);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[2] = monsterEvent;

        monsterEvent = new MonsterEvent(8, 9);
        monster = new BleakGhost();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[3] = monsterEvent;

        monsterEvent = new MonsterEvent(11, 12);
        monster = new BleakDog();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[4] = monsterEvent;

        monsterEvent = new MonsterEvent(14, 14);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[5] = monsterEvent;

        monsterEvent = new MonsterEvent(16, 17);
        monster = new BleakGhost();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[6] = monsterEvent;

        monsterEvent = new MonsterEvent(19, 19);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[7] = monsterEvent;

        monsterEvent = new MonsterEvent(20, 25);
        monster = new SneakMan();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[8] = monsterEvent;

        monsterEvent = new MonsterEvent(27, 28);
        monster = new BleakDog();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[9] = monsterEvent;

        monsterEvent = new MonsterEvent(30, 30);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[10] = monsterEvent;

        monsterEvent = new MonsterEvent(32, 32);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[11] = monsterEvent;

        monsterEvent = new MonsterEvent(34, 35);
        monster = new BleakGhost();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[12] = monsterEvent;

        monsterEvent = new MonsterEvent(37, 37);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[13] = monsterEvent;

        monsterEvent = new MonsterEvent(39, 39);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[14] = monsterEvent;

        monsterEvent = new MonsterEvent(40, 45);
        monster = new OctopusMan();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[15] = monsterEvent;

        monsterEvent = new MonsterEvent(47, 47);
        monster = new HungryMoster();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[16] = monsterEvent;

        monsterEvent = new MonsterEvent(49, 49);
        monster = new ScarletLimax();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[17] = monsterEvent;

        monsterEvent = new MonsterEvent(51, 52);
        monster = new BleakGhost();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[18] = monsterEvent;

        monsterEvent = new MonsterEvent(54, 59);
        monster = new ArmBrokenKnight();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[19] = monsterEvent;

        monsterEvent = new MonsterEvent(60, 60);
        monster = new BlackBarrier();
        monsterEvent.monster = monster;
        this.sceneMonster[0].myMonsters[20] = monsterEvent;
    }

    private void InitBattleCard()
    {
        // 初始卡牌
        // 卡牌加入一张跳劈卡
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());
        BattleCardArray.GetInstance().AddBattleCard(new MoveAgainCard());

        this.sceneBattleCard = new BattleCardMap[3];
        BattleCardMap levelOne = new BattleCardMap(60);
        this.sceneBattleCard[0] = levelOne;

        BattleCardEvent cardEvent;
        cardEvent = new BattleCardEvent
        {
            one = new Fireball(),
            two = new JumpCut()
        };

        // 全部卡牌事件都变成 火球 跳劈
        // i代表格数
        for(int i = 1; i< 60; i+=2)
        {
            this.sceneBattleCard[0].myCardEvent[i] = cardEvent;
        }


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
        levelOne.myBuffs[25] = be1;

        // 全部卡牌事件都变成 火球 跳劈
        for (int i = 0; i < 60; i+=2)
        {
            levelOne.myBuffs[i] = be1;
        }


    }
}
