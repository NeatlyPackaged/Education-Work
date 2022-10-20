using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public new SpriteRenderer renderer;
    public int flickerAmnt;
    public float flickerDuration;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        StartCoroutine(DamageFlicker());
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
            //Destroy(gameObject);
        }
    }

    IEnumerator DamageFlicker()
    {

        for (int i = 0; i < flickerAmnt; i++)
        {
            renderer.color = new Color(1f, 1f, 1f, .5f);
            yield return new WaitForSeconds(flickerDuration);
            renderer.color = Color.white;
            yield return new WaitForSeconds(flickerDuration);
        }

    }
   
}
