using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Animations;

public class TapesUI : MonoBehaviour
{
    public GameObject TextToMenu;
    public Animator anim;

    // Start is called before the first frame update
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

    public void OpenVideo1()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=i2PqTT9wl9M&ab_channel=MartinWalls");
    }

    public void OpenVideo2()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=iTFnNOL4hwg&ab_channel=MartinWalls");
    }

    public void OpenVideo3()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=egPO9kUJehU&ab_channel=MartinWalls");
    }

}
