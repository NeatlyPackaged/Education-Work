using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class Credits : MonoBehaviour
{
        
    public Animator anim;

    void Start()
    {
        
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            anim.SetBool("Pressed", true);
            StartCoroutine(Backgame());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    IEnumerator Backgame()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);
    }

    public void GoGame()
    {
        Debug.Log("HitPlay");
        anim.SetBool("Pressed", true);
        StartCoroutine(Backgame());
    }

    public void QuitGame()
    {
        anim.SetBool("Pressed", true);
        new WaitForSeconds(5);
        Debug.Log("Quitted");
        Application.Quit();
    }

    public void OpenChannel()
    {
        Application.OpenURL("https://www.patreon.com/TheWaltenFiles");
    }

}