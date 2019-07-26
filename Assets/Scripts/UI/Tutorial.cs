using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject log;

    public GameObject show;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExitTutorial()
    {
        StartCoroutine(Exit());
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(0.3f);
        show.SetActive(false);
        log.SetActive(true);
    }
}
