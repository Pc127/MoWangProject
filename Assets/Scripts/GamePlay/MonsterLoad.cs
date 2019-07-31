using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLoad : MonoBehaviour
{
    // 棋盘信息
    private ChessBoard chessBoard;

    public GameObject scene;

    private Dictionary<int, GameObject> monsterMap;

    void Start()
    {
        GamePlay.GetInstance().monsterLoad = this;
        this.chessBoard = GamePersist.GetInstance().chessBoards[GamePersist.GetInstance().currentLevel];

        monsterMap = new Dictionary<int, GameObject>();
    }

    public void LoadMonster(string name, int index)
    {
        if (monsterMap.ContainsKey(index))
            return;

        // 初始化一个怪物图片
        GameObject obj = new GameObject();
        obj.name = "" + index;
        obj.SetActive(true);

        obj.transform.parent = scene.transform;

        SpriteRenderer sp = obj.AddComponent<SpriteRenderer>();

        sp.sprite = Resources.Load<Sprite>("Monster/" + name);

        // 加入Map
        monsterMap.Add(index, obj);

        obj.transform.localScale = new Vector3(10, 10, 0);
        // 计算位置
        sp.transform.localPosition = new Vector3(-chessBoard.cells[index].position.x - 60, -chessBoard.cells[index].position.y -60, 0);
        Debug.Log(sp.transform.localPosition);
    }

    public void UnloadMonster(int index)
    {
        Transform t = scene.transform.Find("" + index);
        // 销毁对象
        Destroy(t.gameObject);
    }


}
