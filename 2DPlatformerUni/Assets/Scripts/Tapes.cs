using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tapes : MonoBehaviour
{
    
    public static int tapes = 0;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tape")
        {
            Debug.Log("TapeCollected" + tapes);
            tapes++;
            Destroy(other.gameObject);
        }
    }

}
