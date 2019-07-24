using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBuffUI : MonoBehaviour
{
    public GameObject buffPrefab;

    // buff之间的间距
    public int distant;

    private int cursor;

    // Start is called before the first frame update
    void Start()
    {
        GamePlay.GetInstance().showBuffUI = this;
        cursor = 0;
    }

    // Update is called once per frame
    public void AddBuff(Buff buff)
    {
        GameObject obj = GameObject.Instantiate(buffPrefab);

        ShowBuffLogo logo = obj.GetComponent<ShowBuffLogo>();

        logo.InitBuff(buff);
        logo.gameObject.SetActive(true);
        logo.transform.parent = this.transform;
        logo.transform.localScale = new Vector3(1, 1, 0);
        logo.transform.localPosition = new Vector3(cursor * distant, 0, 0);

        cursor++;
    }
}
