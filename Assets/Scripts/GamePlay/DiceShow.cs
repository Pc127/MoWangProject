using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceShow : MonoBehaviour {

    public GameObject show;

    public List<Sprite> sprites;

    public Image num;

    // 注册到gamePlay
	void Start () {
        this.show.SetActive(false);	
	}

    public void ShotDice(int index)
    {
        // 更新骰子展示
        this.show.SetActive(true);
        num.sprite = sprites[index - 1];
        StartCoroutine(ShotDiceCo(1));
    }

    IEnumerator ShotDiceCo(float sec)
    {
        yield return new WaitForSeconds(sec);

        this.show.SetActive(false);
    }
}
