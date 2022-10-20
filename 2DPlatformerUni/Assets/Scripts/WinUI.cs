using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class WinUI : MonoBehaviour
{
    public static float time;
    public float timeTillText;
    public GameObject TextToMenu;
    public GameObject TextQuit;
    public GameObject TextExplanation;
    public Animator anim;

    void Start()
    {
        TextToMenu.SetActive(false);
        TextQuit.SetActive(false);
        TextExplanation.SetActive(false);
        time = 0.0f;
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(WaitTillInput());
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
    IEnumerator WaitTillInput()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeTillText);
        TextExplanation.SetActive(true);
        TextToMenu.SetActive(true);
        TextQuit.SetActive(true);
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

    

}
