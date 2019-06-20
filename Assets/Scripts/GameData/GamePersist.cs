using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist : MonoBehaviour
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
            // 加入事件
            BuffEvent be = new BuffEvent();
            be.buffOne = new BattleMemory(5);
            be.buffTwo = new ElementPerception(5);
            this.sceneBuffEvents[0].myBuffs[i] = be;
        }
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

    // 保存三个棋盘
    public ChessBoard[] chessBoards;

    // 保存三个buffer棋盘事件
    public BuffEvents[] sceneBuffEvents;

    public int currentLevel;
}
