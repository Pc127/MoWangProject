using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(StartGameCo(0.7f));
    }

    IEnumerator StartGameCo(float sec)
    {
        yield return new WaitForSeconds(sec);

        SceneManager.LoadScene("Prologue");
    }
}
