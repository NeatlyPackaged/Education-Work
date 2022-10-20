using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public bool isWin;
    public bool isDoor;
    public Image EKey;
    public int animatronics;
    public int totalAnimatronics;
    public AudioSource winner;
    public GameObject winText;
    public int duration;

    // Start is called before the first frame update
    private void Start()
    {
        winText.SetActive(false);
        EKey.gameObject.SetActive(false);
        isWin = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(animatronics >= totalAnimatronics)
        {
            duration++;
            
            isWin = true;
        }

        if (isDoor && Input.GetKeyDown(KeyCode.E))
        {

            //rend.material.color = colorToTurnInto;
            //rend.sortingOrder = 0;

            //Physics2D.IgnoreLayerCollision(8, 9, true);
            Debug.Log("Enter Door");
            SceneManager.LoadScene(4);
        }

        if (duration >= 1 && duration <= 250)
        {
            winner.Play();
            winText.SetActive(true);
            //yield return new WaitForSeconds(3.5f);
            
        } else if (duration >= 254)
        {
            winText.SetActive(false);
            duration = 255;
        }
        

    }




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Animatronic")
        {
            animatronics++;
            Debug.Log("TapeCollected" + animatronics);
            Destroy(other.gameObject);
        }

        if (other.tag == "WinDoor")
        {
            if (isWin == true)
            {
                Debug.Log("congratulations");
                EKey.gameObject.SetActive(true);
                isDoor = true;
            }

           


            //Destroy(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "WinDoor")
        {
            EKey.gameObject.SetActive(false);
            isDoor = false;
        }
    }
}
