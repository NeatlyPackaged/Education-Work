using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class TitleSequence : MonoBehaviour
{
    public static float time;
    public float timeTillText;
    public GameObject Text;
    public GameObject TextCredits;
    public GameObject TextTapes;
    public GameObject TextQuit;
    public Animator anim;

    void Start()
    {
        Text.SetActive(false);
        TextTapes.SetActive(false);
        TextCredits.SetActive(false);
        TextQuit.SetActive(false);
        time = 0.0f;
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(WaitTillInput());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("Pressed", true);
            StartCoroutine(Startgame());
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            TextCredits.SetActive(true);
            Text.SetActive(true);
            TextTapes.SetActive(true);
            TextQuit.SetActive(true);
        }
    }
    IEnumerator WaitTillInput()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeTillText);
        TextCredits.SetActive(true);
        Text.SetActive(true);
        TextTapes.SetActive(true);
        TextQuit.SetActive(true);
    }

    IEnumerator Startgame()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(1);
    }

    IEnumerator StartCredits()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(5);
    }

    IEnumerator StartTapes()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(6);
    }

    public void GoGame()
    {
        Debug.Log("HitPlay");
        anim.SetBool("Pressed", true);
        StartCoroutine(Startgame());
    }

    public void Credits()
    {
        anim.SetBool("Pressed", true);
        StartCoroutine(StartCredits());
        
    }

    public void Tapes()
    {
        anim.SetBool("Pressed", true);
        StartCoroutine(StartTapes());
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
