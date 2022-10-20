using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    private float timeBtwShots = 1.5f;
    public float startTimeBtwShots = 1.5f;




    public Transform player;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (timeBtwShots <= 0)
        {
            GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.transform.parent = null;
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
