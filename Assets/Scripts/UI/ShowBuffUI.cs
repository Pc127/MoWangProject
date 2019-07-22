using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBuffUI : MonoBehaviour
{
    public GameObject buffPrefab;

    // buff之间的间距
    public int distant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void AddBuff(Buff buff)
    {
        GameObject obj = GameObject.Instantiate(buffPrefab);

        ShowBuffLogo logo = obj.GetComponent<ShowBuffLogo>();
    }
}
