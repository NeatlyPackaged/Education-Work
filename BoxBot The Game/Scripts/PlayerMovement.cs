using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float jumpForce = 0f;
    private Rigidbody2D rb;
    private bool cantJump;
    public BoxBotCode controller;
    public Animator animator;
    public bool isHiding;
    private bool CanHide;
    public GameObject HidingBox;
    public GameObject Player;
    public static bool JumpEnabled;
    public float jumpTimeCounter = 1f;
    private SpriteRenderer rend;
    public Image EKey;



    [SerializeField]
    private Color colorToTurnInto = Color.gray;

    private void Start()
    {
        EKey.gameObject.SetActive(false);
        JumpEnabled = true;
        cantJump = false;
        isHiding = false;
       
        rend = GetComponent<SpriteRenderer>();
    }

    

    // Update is called once per frame
    void Update()
    {
        

        animator.SetFloat("Speed", Mathf.Abs(controller.moveInput));


        // if the player jumps but is grounded and that if you are not running or crawling then this command will work
        if (Input.GetButton("Jump") && JumpEnabled == true && controller.isGrounded == true && controller.isCrawling == false && controller.isRunning == false && isHiding == false )
        {
            
            if (cantJump == false)
            {
            // this will start a counter
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;

            }


            // when jumping the players speed will stop and on release will return to normal
            controller.speed = 0;
            animator.SetBool("IsJumping", true);

            } else if (cantJump == true)
            {
                JumpEnabled = false;
            }
            

        }

        //these are all the different jump forces that will happen based on whatever time you let go of space
        if (jumpTimeCounter <= 0.19 && jumpTimeCounter >= 0)
        {
            jumpForce = 11;
           
        }

        if (jumpTimeCounter <= 0.39 && jumpTimeCounter >= 0.20)
        {
            jumpForce = 9;
            
        }
        if (jumpTimeCounter <= 0.59 && jumpTimeCounter >= 0.40)
        {
            jumpForce = 7;

        }

        if (jumpTimeCounter <= 0.79 && jumpTimeCounter >= 0.60)
        {
            jumpForce = 5;

        }

        if (jumpTimeCounter <= 1 && jumpTimeCounter >= 0.80)
        {
            jumpForce = 3;

        }


        // all of this happens when you release the space bar
        if (Input.GetButtonUp("Jump") && controller.isGrounded == true && JumpEnabled == true)
        {
            if (cantJump == false)
            {
                Debug.Log(jumpTimeCounter);
            controller.isGrounded = false;
            controller.rb.velocity = Vector2.up * jumpForce;
            controller.speed = 1.75f;
            
            
            animator.SetBool("EndJump", true);

            //this will reset the counter but doesnt mean you can repeat the code because of the parameter of isgrounded
            jumpTimeCounter = 1f;
                StartCoroutine(Waiting());
                
            }
            else if (cantJump == true)
            {
                JumpEnabled = false;
            }

        }

        IEnumerator Waiting()
        {

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(0.1f);

            animator.SetBool("EndJump", false);
            animator.SetBool("IsJumping", false);
        }




        if (CanHide && Input.GetKeyDown(KeyCode.E))
        {
           
            rend.material.color = colorToTurnInto;
            rend.sortingOrder = 0;
            isHiding = true;
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Debug.Log("Hiding");
            HidingBox.SetActive(false);
            cantJump = true;
            controller.speed = 0f;
            JumpEnabled = false;
        }

        else if (isHiding = true && Input.GetKeyUp(KeyCode.E))
        {
            rend.material.color = Color.white;
            rend.sortingOrder = 2;
            isHiding = false;
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Debug.Log("Not Hiding");
            controller.speed = 1.75f;
            cantJump = false;
            HidingBox.SetActive(true);
            JumpEnabled = true;
        }
        

       
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "HideBox")
        {
            EKey.gameObject.SetActive(true);
            CanHide = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "HideBox")
        {
            EKey.gameObject.SetActive(false);
            CanHide = false;
        }
    }
    



}
