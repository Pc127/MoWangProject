using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GamePersist.GetInstance().currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
