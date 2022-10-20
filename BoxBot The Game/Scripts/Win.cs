using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject Police;
    bool exit = false;
    public Animator Vent;
    public bool ZoomActive;
    public Camera PixelCam;
    public GameObject PixelCamera;
    public Camera ZoomCam;
    public Vector3[] Target;
    public timer WinTime;
    public Image EKey;


    public Camera Cam;

    public float Speed;

    void Start()
    {
        Cam = Camera.main;




    }

    private void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.E) && exit == true)
        {
            WinTime.TimerStop();
            ZoomActive = true;
            Vent.SetBool("Interacted", true);
            Police.SetActive(false);
            StartCoroutine(Winning());
            
           
        }
    }

    public void LateUpdate()
    {
        if (ZoomActive)
        {
            PixelCamera.SetActive(false);
            
            Cam = ZoomCam;
            
        }
        else
        {
            Cam = PixelCam;
        }
    }
    IEnumerator Winning()
    {
        yield return new WaitForSeconds(1);
        
        
        SceneManager.LoadScene(4);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Vent")
        {
            EKey.gameObject.SetActive(true);
            exit = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Vent")
        {
            EKey.gameObject.SetActive(false);
            exit = false;
        }

    }
}
