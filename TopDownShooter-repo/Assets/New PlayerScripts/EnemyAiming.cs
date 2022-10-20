using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    private Transform player;
    private Vector3 target;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        target = player.transform.position;

        Vector3 temp = target - transform.position;
        temp.z = 0;

        transform.up = temp;
       
    }
}
