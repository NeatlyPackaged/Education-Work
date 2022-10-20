using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumper : MonoBehaviour
{
    public bool roofCheck;
    public void Awake()
    {
        roofCheck = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Roof")
        {
            Debug.Log("HitR");
            roofCheck = true;
            


        }
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Roof")
        {
            Debug.Log("NoHitR");
            roofCheck = false;



        }
        
    }
}
