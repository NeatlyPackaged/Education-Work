using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public static float time;
    public Text timerDisplay;
    private string minute_s;
    private string second_s;
    public GameObject player;



    private void Awake()
    {
        GameObject player = GameObject.FindWithTag("Player");
        time = 15f;
    }
    //the raw time
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        UIDisplay(time);

        if(time == 0)
        {
            Destroy(player);
        }
    }
    //converting it [0:00] format and displaying it
    void UIDisplay(float displayTime)
    {

        if (displayTime < 0)
        {
            displayTime = 0;
        }

        float minutes = Mathf.FloorToInt(displayTime / 60); 
        //floor to int rounds time down to a whole number
        float seconds = Mathf.FloorToInt(displayTime % 60); 
        // the % sign essentially finds the remainder after dividing displayTime by 60, which are our seconds

        //converting the floats into strings so they can be displayed
        minute_s = minutes.ToString();
        second_s = seconds.ToString();

        //updating the text UI element to show the correct time in minutes and seconds
        timerDisplay.text = minute_s + ":" + second_s;
    }
}
