using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameObject FallPoint;
    public GameObject Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ToHide")
        {
            Player.transform.position = FallPoint.transform.position;



        }

    }
}
