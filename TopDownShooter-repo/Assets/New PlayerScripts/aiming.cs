using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        //Debug.Log(Input.mousePosition);

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mouse);

        worldPoint.z = 0;


        Vector3 dir = worldPoint - transform.position ;

        //float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.up = dir;
    }
}
