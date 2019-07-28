using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuccessEnd : MonoBehaviour
{
    public GameObject show;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Demon.GetInstance().live)
            return;

        DoSuccess();
    }

    void DoSuccess()
    {
        show.SetActive(true);
        StartCoroutine(DoSuccessCo());
    }

    IEnumerator DoSuccessCo()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu");
    }
}
