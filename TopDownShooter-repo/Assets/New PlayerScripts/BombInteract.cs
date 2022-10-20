using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BombInteract : MonoBehaviour
{
    public bool isDoor;
    public bool isBomb;
    public bool activeBomb;
    //private SpriteRenderer rend;
    public Image EKey;
    public Text Countdown;
    public GameObject BombSprite;
    public GameObject textDisplay;
    public GameObject Enemies1;
    public GameObject Enemies2;
    public float timeRemaining = 10;


    //[SerializeField]
    //private Color colorToTurnInto = Color.gray;

    // Start is called before the first frame update
    private void Start()
    {
        EKey.gameObject.SetActive(false);
        BombSprite.gameObject.SetActive(false);
        textDisplay.gameObject.SetActive(false);
        Enemies1.SetActive(true);
        Enemies2.SetActive(false);
        //rend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDoor && activeBomb && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Enter Door");
            SceneManager.LoadScene("Win");
        }

        if (isBomb && Input.GetKeyDown(KeyCode.E))
        {
            activeBomb = true;
            Enemies1.SetActive(false);
            Enemies2.SetActive(true);


        }
        if (activeBomb)
        {
            BombSprite.gameObject.SetActive(true);
            textDisplay.gameObject.SetActive(true);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                //When the Time Ends, The Game Will load to the game over Screen
                Debug.Log("Time has run out!");
                SceneManager.LoadScene("DeathByExplosion");
                timeRemaining = 0;
                activeBomb = false;
            }
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        Countdown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Door")
        {
            EKey.gameObject.SetActive(true);
            isDoor = true;
        }

        if (other.gameObject.tag == "Bomb")
        {
            EKey.gameObject.SetActive(true);
            isBomb = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            EKey.gameObject.SetActive(false);
            isDoor = false;
        }

        if (other.gameObject.tag == "Bomb")
        {
            EKey.gameObject.SetActive(false);
            isBomb = false;
        }
    }
}
