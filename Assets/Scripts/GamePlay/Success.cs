using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Success : MonoBehaviour
{
    public GameObject show;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var item in GamePersist.GetInstance().GetMonsterEvents().myMonsters)
        {
            if (item.monster.live)
                return;
        }

        show.SetActive(true);
    }
}
