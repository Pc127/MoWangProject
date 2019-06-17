using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Transform scene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeMove());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeMove()
    {
        while (true)
        {

            if (Input.GetKey(KeyCode.Space))
            {
                // 局部坐标移动
                scene.localPosition += new Vector3(-150, 75, 0);
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
