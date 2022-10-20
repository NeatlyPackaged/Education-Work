using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    
    private Rigidbody2D rb;

    private Camera theCam;

    // private static float speed = 5f;

    private static float fireRate = 0.5f;
    private static float nextFire = 0f;

    //public static float MoveSpeed { get => speed; set => speed = value; }

    public static float FireRate { get => fireRate; set => fireRate = value; }

    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletToFire;

    public static int collectedAmount;

    private void Awake()
    {
        fireRate = 0.5f;
        // speed = 5f;
        if (!instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        fireRate = 0.5f;
        //speed = 5f;
        theCam = Camera.main;
        //rb = GetComponent<Rigidbody2D>();
        

    }


    void Update()
    {
       // speed = MoveSpeed;
       // rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        /*Vector3 mouse = Input.mousePosition;
        //Debug.Log(Input.mousePosition);

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,angle);*/

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletToFire, firePoint.position, transform.rotation);
        }

        

    }


    public static void MoveSpeedChange(float speed)
    {
       // MoveSpeed += speed;
    }


    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }


}

