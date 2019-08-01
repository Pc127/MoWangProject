using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassToScene : MonoBehaviour
{
    public int level;
    
    public void ToScene()
    {
        SceneManager.LoadScene("SceneOne");
    }
}
