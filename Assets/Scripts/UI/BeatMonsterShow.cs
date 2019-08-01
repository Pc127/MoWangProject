using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMonsterShow : MonoBehaviour {

    public GameObject show;

    public List<Sprite> sprites;

    // 注册到BattleUI
    void Start()
    {
        this.show.SetActive(false);
    }

    public void BeatMonster()
    {
        this.show.SetActive(true);
        StartCoroutine(BeatMonsterCo(2.0f));
    }

    IEnumerator BeatMonsterCo(float sec)
    {
        yield return new WaitForSeconds(sec);

        this.show.SetActive(false);
    }
}
