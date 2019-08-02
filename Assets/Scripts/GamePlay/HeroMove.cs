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

    private Hide myHide;

    public Animator animator;

    //Hero的spr
    private SpriteRenderer sp;
    
    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
        animator.enabled = false;

        myFace = Face.FRONT_RIGHT;
        myHide = Hide.BEHIND;
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
        if(myFace == Face.FRONT_LEFT || myFace == Face.FRONT_RIGHT)
            animator.enabled = true;
        // 隐藏色子
        GamePlay.GetInstance().HideMoveDice();

        for(int i = 0; i<stepCount; i++)
        {
            // 每行动一格调用一次
            BuffArray.GetInstance().MoveStep(1);
            ++this.heroPos;
            if (heroPos == this.chessBoard.cellCount)
            {
                heroPos = 0;
                // 一轮结束触发Buff
                BuffArray.GetInstance().RoundOver();
                BattleCardArray.GetInstance().Reflash();

                // 更新圈数
                EventManager.GetInstance().circulCount++;
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
                        animator.enabled = false;
                        break;
                    case Face.BACK_RIGHT:
                        sp.sprite = this.back;
                        sp.flipX = false;
                        animator.enabled = false;
                        break;
                }
            }

            if(myHide != chessBoard.cells[heroPos].hide)
            {
                myHide = chessBoard.cells[heroPos].hide;

                switch (myHide)
                {
                    case Hide.BEHIND:
                        sp.sortingOrder = 7;
                        break;
                    case Hide.FRONT:
                        sp.sortingOrder = 12;
                        break;
                }
            }
            // 进行移动
            yield return new WaitForSeconds(0.2f);
        }
        
        GamePlay.GetInstance().heroPos = this.heroPos;
        
        EventManager.GetInstance().InvokeEvent();

        animator.enabled = false;
        
    }
}
