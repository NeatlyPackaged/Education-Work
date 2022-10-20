using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetect : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ToHide")
        {
            Player.transform.position = SpawnPoint.transform.position;
            
            
            Debug.Log("Caught");
        }

    }
}
