using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public Transform scene;

    public int heroPos;

    public ChessBoard chessBoard;

    // Start is called before the first frame update
    void Start()
    {
        GamePlay.GetInstance().heroPos = 0;
        this.heroPos = 0;
        this.chessBoard = GamePersist.GetInstance().GetChessBoard();
        this.scene.localPosition = new Vector3(chessBoard.cells[0].position.x, chessBoard.cells[0].position.y, 0);

        GamePlay.GetInstance().heroMove = this;
    }


    public void MakeMove(int stepCount)
    {
        // 进行移动
        StartCoroutine(Move(stepCount));
    }

    IEnumerator Move(int stepCount)
    {
        // 隐藏色子
        GamePlay.GetInstance().HideMoveDice();

        for(int i = 0; i<stepCount; i++)
        {
            ++this.heroPos;
            if (heroPos == this.chessBoard.cellCount)
                heroPos = 0;
            this.scene.localPosition = new Vector3(chessBoard.cells[heroPos].position.x, chessBoard.cells[heroPos].position.y, 0);
            // 进行移动
            yield return new WaitForSeconds(0.2f);
        }
        
        GamePlay.GetInstance().heroPos = this.heroPos;
        // 激活棋盘上的事件
        GamePlay.GetInstance().InvokeEvent();
    }
}
