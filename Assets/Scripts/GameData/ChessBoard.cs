using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 棋子朝向
public enum Face { BACK_RIGHT, BACK_LEFT, FRONT_RIGHT, FRONT_LEFT };
public enum Hide { BEHIND, FRONT};

// 棋子格子
public struct Cell
{
    public Vector2 position;
    public Face face;
    public Hide hide;
}


public class ChessBoard
{
    // 棋盘格子数量
    public int cellCount;

    // 主角位置
    public int heroPosition;

    // 格子
    public Cell[] cells;

    // 初始位置
    public Vector2 origin;

    // 构造函数
    public ChessBoard(int cellCount)
    {
        // 初始位于第0格
        // 起点
        heroPosition = 0;

        // 棋盘格子数量
        this.cellCount = cellCount;

        // 棋盘的格子
        cells = new Cell[cellCount];
    }

    public void Build(Vector2 origin, int xOffset, int yOffset, int cellCountFirst, int cellCountSecond)
    {
        // 起点
        this.origin = origin;

        // 首列
        for(int i = 0; i<cellCountFirst; ++i)
        {
            Cell cell = new Cell();
            // 计算位置
            cell.position = origin + i *  new Vector2(-xOffset, yOffset);
            cell.face = Face.FRONT_RIGHT;
            cell.hide = Hide.BEHIND;
            // 加入数组
            cells[i] = cell;
        }

        // 次列
        for(int i = cellCountFirst; i<cellCountFirst + cellCountSecond -1; ++i)
        {
            Cell cell = new Cell();
            // 计算位置
            cell.position = cells[i-1].position + new Vector2(xOffset, yOffset);
            cell.face = Face.FRONT_LEFT;
            cell.hide = Hide.FRONT;
            // 加入数组
            cells[i] = cell;
        }

        // 三列
        for(int i = cellCountFirst + cellCountSecond -1; i< 2 * cellCountFirst + cellCountSecond -2; ++i)
        {
            Cell cell = new Cell();
            cell.position = cells[i - 1].position + new Vector2(xOffset, -yOffset);
            cell.face = Face.BACK_LEFT;
            cell.hide = Hide.FRONT;
            cells[i] = cell;
        }

        // 四列
        for(int i = 2*cellCountFirst +cellCountSecond -2; i<cellCount -1; ++i)
        {
            Cell cell = new Cell();
            cell.position = cells[i - 1].position + new Vector2(-xOffset, -yOffset);
            cell.face = Face.BACK_RIGHT;
            cell.hide = Hide.FRONT;
            cells[i] = cell;
        }
    }
}
