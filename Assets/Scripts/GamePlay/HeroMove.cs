using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public Transform scene;

    public int heroPos;

    public ChessBoard chessBoard;

    public Sprite front;

    public Sprite back;

    private Face myFace;

    private SpriteRenderer sp;
    
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();

        myFace = Face.FRONT_RIGHT;
        GamePlay.GetInstance().heroPos = 0;
        this.heroPos = 0;
        this.chessBoard = GamePersist.GetInstance().GetChessBoard();
        this.scene.localPosition = new Vector3(chessBoard.cells[0].position.x, chessBoard.cells[0].position.y, 0);

        GamePlay.GetInstance().heroMove = this;
    }

    // 不触发行动的移动
    public void MakeMoveWithoutAction(int stepCount)
    {
        StartCoroutine(Move(stepCount, false));
    }

    // 触发行动的移动
    public void MakeMove(int stepCount)
    {
        // 进行移动
        StartCoroutine(Move(stepCount, true));
    }

    IEnumerator Move(int stepCount, bool actionEnable)
    {
        // 隐藏色子
        GamePlay.GetInstance().HideMoveDice();

        for(int i = 0; i<stepCount; i++)
        {
            ++this.heroPos;
            if (heroPos == this.chessBoard.cellCount)
            {
                heroPos = 0;
                // 一轮结束触发Buff
                BuffArray.GetInstance().RoundOver();
            }
                

            // 如果遇到怪物就在这里停顿
            if (EventManager.GetInstance().MeetMonster(heroPos))
            {
                break;
            }
                
            this.scene.localPosition = new Vector3(chessBoard.cells[heroPos].position.x, chessBoard.cells[heroPos].position.y, 0);
            
            // 变换角色朝向
            if(myFace != chessBoard.cells[heroPos].face)
            {
                myFace = chessBoard.cells[heroPos].face;

                switch (myFace)
                {
                    case Face.FRONT_RIGHT:
                        sp.sprite = this.front;
                        sp.flipX = true;
                        break;
                    case Face.FRONT_LEFT:
                        sp.sprite = this.front;
                        sp.flipX = false;
                        break;
                    case Face.BACK_LEFT:
                        sp.sprite = this.back;
                        sp.flipX = true;
                        break;
                    case Face.BACK_RIGHT:
                        sp.sprite = this.back;
                        sp.flipX = false;
                        break;
                }
            }
            // 进行移动
            yield return new WaitForSeconds(0.2f);
        }
        
        GamePlay.GetInstance().heroPos = this.heroPos;

        {
            EventManager.GetInstance().InvokeEvent();
        }
    }
}
