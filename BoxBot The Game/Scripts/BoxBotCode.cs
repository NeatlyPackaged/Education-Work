using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBotCode : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float moveInput;
    public PlayerMovement controller2;
    
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;


    public bool isJumping;
    public bool isGrounded;
    public bool isCrawling;
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.75f;
        isJumping = false;
        isCrawling = false;
        isRunning = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        

        moveInput = Input.GetAxisRaw("Horizontal") * speed;
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        

        
    }

    // Update is called once per frame
    void Update()
    {
        //This is used to check what the ground is by using a circle
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        //this is used to flip the player when he moves the other direction
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

       /* // this will change the speed to the crouching speed
        if (Input.GetKey(KeyCode.LeftControl) && isRunning == false && isJumping == false)
        {
            speed = 0.75f;
            isCrawling = true;
            isRunning = false;
            isJumping = false;
        } // this will change the speed to the Running Speed
        else if (Input.GetKey(KeyCode.LeftShift) && isCrawling == false && isJumping == false)
        {
            isCrawling = false;
            isRunning = true;
            isJumping = false;
            speed = 2;
        } */// this will change the speed to the jump speed
       /* else if (Input.GetKey(KeyCode.Space) && isRunning == false && isCrawling == false )
        {
            isCrawling = false;
            isRunning = false;
            isJumping = true;
            speed = 0;
        }// this will change the speed to the default speed as long as none of the bools are active
       /* else if (isRunning == false && isCrawling == false && isJumping == false )
        {
            speed = normSpeed;
        }*/
        // this will ensure that no matter if you are grounded, these will remain false
        if (isGrounded == true)
        {
            isCrawling = false;
            isRunning = false;
            isJumping = false;
        }

    }

}
