using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TapeCollector : MonoBehaviour
{
    
    public static int tapesCol;
    public int collection;
   


    // Start is called before the first frame update
    void Awake()
    {
        
        DontDestroyOnLoad(this.gameObject);
       
    }

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tapesCol = Tapes.tapes;

    }
   
}
