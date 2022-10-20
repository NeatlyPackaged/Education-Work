using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public Image healthBar;
    public bool hasHealthbar;
    public GameObject ability;
    public GameObject player;
    public GameObject healthUI;

    public SpriteRenderer sprite;



    private void Start()
    {
       // healthUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (hasHealthbar)
        {

            healthBar.fillAmount = health;
        }


    }

    /*public IEnumerator FlashRed()
    {
        //healthUI.SetActive(true);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(1f);
        //healthUI.SetActive(false);

    }*/



    public void TakeDamage(float damage)
    {


        health -= damage;
        if (health <= 0f)
        {


            int powerup = 1;

            if (Random.Range(0, 10) == powerup)
            {
                Instantiate(ability, transform.position, player.transform.rotation);
            }
            Timer.time += 5;
            ScoreSystem.Instance.AddScore(5);
            Destroy(gameObject);







        } 

        //StartCoroutine(FlashRed());
    }
}