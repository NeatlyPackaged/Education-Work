using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDirection : MonoBehaviour
{

    float currentTime = 0f;
    float StartingTime = 12f;
    public GameObject left;
    public GameObject right;
    public Animator Drinking;
    private bool DoneDrink;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = StartingTime;
        Drinking.SetBool("DrinkDown1", false);
        Drinking.SetBool("DrinkDown2", false);
        Drinking.SetBool("Finished", false);
        Drinking.SetBool("Spin", false);
        Drinking.SetBool("HasDrunk", false);
        left.SetActive(false);
        right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        

        currentTime -= 1 * Time.deltaTime;
        if (currentTime >= 9f && currentTime <= 10f)
        {
            DoneDrink = false;
            //Debug.Log("Start");
            left.SetActive(false);
            right.SetActive(true);
            Drinking.SetBool("DrinkDown1", true);
            Drinking.SetBool("DrinkDown2", false);
            Drinking.SetBool("HasDrunk", false);
            StartCoroutine(waiter());

            Drinking.SetBool("Spin", true);

        }
        else if (currentTime >= 6f && currentTime <= 8.9f)
        {
            //Debug.Log("Mid");
            Drinking.SetBool("Spin", false);
            Drinking.SetBool("DrinkDown1", false);
            Drinking.SetBool("HasDrunk", false);
            left.SetActive(true);
            right.SetActive(false);

        }
        else if (currentTime >= 0f && currentTime <= 4f)
        {
            Drinking.SetBool("DrinkDown2", true);
            StartCoroutine(waiter());
            //Debug.Log("End");
            Drinking.SetBool("DrinkDown1", false);
            StartCoroutine(waiter());
            Drinking.SetBool("HasDrunk", true);
            StartCoroutine(waiter());
            Drinking.SetBool("Finished", true);
            
            

        }
        
        else if (currentTime >= -0.9 && currentTime <= -0.1)
        {
            
            currentTime = StartingTime;
            Drinking.SetBool("Finished", false);
        }


        if (currentTime >= 1.5f && currentTime <= 3.1f)
        {
            DoneDrink = true;
        }

            if (DoneDrink == true)
        {
            left.SetActive(false);
            right.SetActive(true);
        }

        //Debug.Log(currentTime);

    }

    

    IEnumerator waiter()
    {
        //int wait_time = Random.Range(3, 6);
        yield return new WaitForSeconds(1);
        //Debug.Log(wait_time);
    }
}
