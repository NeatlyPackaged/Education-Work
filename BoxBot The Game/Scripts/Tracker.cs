using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public GameObject trackedObject;

    public Camera myCamera;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, trackedObject.transform.position, 1f);

    }
    
}
