using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DropOff")
        {
            Player.transform.position = SpawnPoint.transform.position;


            Debug.Log("Caught");
        }

        if (other.gameObject.tag == "DropOff2")
        {
            Player.transform.position = SpawnPoint2.transform.position;


            Debug.Log("Caught");
        }

        if (other.gameObject.tag == "DropOff3")
        {
            Player.transform.position = SpawnPoint3.transform.position;


            Debug.Log("Caught");
        }

    }
}