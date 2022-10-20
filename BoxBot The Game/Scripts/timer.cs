using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class timer : MonoBehaviour
{
    Text Score_UIText;
    public static float time = 0f;
    public bool isRunning = true;
    private float stopTimer;

    // Start is called before the first frame update
    void Awake()
    {
        Score_UIText = GetComponent<Text>();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (Application.loadedLevelName == "Level 1")
        {
            time = 0.0f;
        }
    }

    public void TimerStop()
    {
        if(isRunning)
        {
            isRunning = false;
            stopTimer = time;
        }
    }

    public void TimerStart()
    {
        if (isRunning)
        {
            isRunning = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;
        }

        

        if (Application.loadedLevelName == "Win")
        {
            TimerStop();
            Score_UIText.text = "You   Took   " + time.ToString("F1") + "   Seconds   to   beat   the   demo";
        }

        if(Application.loadedLevelName == "Level 1")
        {
            TimerStart();
            if (isRunning)
            {
                
                time += Time.deltaTime;
            }
        }


        



        
    }
}
