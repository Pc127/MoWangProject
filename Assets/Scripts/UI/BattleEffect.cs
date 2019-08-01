using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEffect : MonoBehaviour {

    // 战斗特效集中管理
    public Animator animator;

    // 战斗特效种类
    public List<Sprite> effectLogo;

    public Image heroEffect;

    public Image monsterEffect;

	void Start () {
        animator.enabled = false;
        heroEffect.enabled = false;
        monsterEffect.enabled = false;
    }
	
	public void ShowEffect(int hero, int monster)
    {
        heroEffect.enabled = true;
        monsterEffect.enabled = true;
        // 更新logo
        heroEffect.sprite = effectLogo[hero];
        monsterEffect.sprite = effectLogo[monster];

        animator.enabled = true;
        StartCoroutine(HideEffect(1f));
    }

    IEnumerator HideEffect(float sec)
    {
        yield return new WaitForSeconds(sec);
        animator.enabled = false;
        heroEffect.enabled = false;
        monsterEffect.enabled = false;
    }
}
