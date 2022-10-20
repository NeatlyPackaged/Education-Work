using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject Pause;

    void Start()
    {
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Pause.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadMap());
        }
    }

    IEnumerator ReloadMap()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Basement");
    }
}
