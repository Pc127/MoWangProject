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

        // buff事件初始化
        this.sceneBuffEvents = new BuffEvents[3];
        // 初始化 第一个棋盘上的buff事件

        this.sceneBuffEvents[0] = new BuffEvents(60);

        for(int i=0; i < 60; i++)
        {
            // 全部设置为1级buff
            this.sceneBuffEvents[0].myBuffLevel[i] = 1;
        }

        // 怪物事件
        // 数组
        this.sceneMonster = new MonsterEvents[3];
        this.sceneMonster[0] = new MonsterEvents(1);

        // 第一个场景
        MonsterEvent monsterEvent = new MonsterEvent(1, 10);
        // 创建一个小怪物
        monsterEvent.monster = new MyMonster(50,10,10,10,50);

        this.sceneMonster[0].myMonsters[0] = monsterEvent;

        // 卡牌加入一张跳劈卡
        BattleCardArray.GetInstance().AddBattleCard(new JumpCut());
        BattleCardArray.GetInstance().AddBattleCard(new Fireball());

        // 行动牌加入
        Dodge dodge = new Dodge();
        dodge.count = 1;
        dodge.activeCount = 1;

        MoveAgain moveAgain = new MoveAgain();
        moveAgain.count = 1;
        moveAgain.activeCount = 1;
        ActionCardArray.GetInstance().AddActionCard(dodge.name, dodge);
        ActionCardArray.GetInstance().AddActionCard(moveAgain.name, moveAgain);

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
    public BuffEvents GetBuffEvents()
    {
        return sceneBuffEvents[this.currentLevel];
    }

    // 获得当前monster事件
    public MonsterEvents GetMonsterEvents()
    {
        return sceneMonster[this.currentLevel];
    }

    // 保存三个棋盘
    public ChessBoard[] chessBoards;

    // 保存三个buffer棋盘事件
    public BuffEvents[] sceneBuffEvents;

    // 保存三个monster世界
    public MonsterEvents[] sceneMonster;

    public int currentLevel;
}
