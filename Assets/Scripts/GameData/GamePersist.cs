using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersist : MonoBehaviour
{
    // 私有构造函数
    private GamePersist()
    {
        currentLevel = 0;
        this.chessBoards = new ChessBoard[1];

        // 初始化 第一个棋盘
        this.chessBoards[0] = new ChessBoard(60);
        this.chessBoards[0].Build(new Vector2(0, 0), 150, 75, 16, 16);
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

    public ChessBoard GetChessBoard()
    {
        return this.chessBoards[this.currentLevel];
    }

    // 保存三个棋盘
    public ChessBoard[] chessBoards;

    public int currentLevel;
}
