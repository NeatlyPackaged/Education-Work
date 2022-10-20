using UnityEngine;
using System.Collections;



//--------------------------------------------
/*Better Character Controller Includes:
     - Fixed Update / Update Input seperation
     - Better grounding using a overlap box
     - Basic Multi Jump
 */
//--------------------------------------------
public class BetterCharacterController : MonoBehaviour
{
    protected bool facingRight = true;
    protected bool jumped;
    public int maxJumps;
    protected int currentjumpCount;
    public Animator animator;

    public float speed;
    public float crouchSpeed;
    public float slideSpeed;
    public float runSpeed;
    float originalSpeed;
    public float jumpForce = 1000;

    private float horizInput;

    public bool grounded;

    public Rigidbody2D rb;

    public LayerMask groundedLayers;

    protected Collider2D charCollision;
    protected Vector2 playerSize, boxSize;

    
    public float slideDuration;
    bool isSliding;
    bool isCrouching;
    


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        charCollision = GetComponent<Collider2D>();
        playerSize = charCollision.bounds.extents;
        boxSize = new Vector2(playerSize.x, 0.05f);
        originalSpeed = speed;
    }

    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizInput));
        animator.SetFloat("YSpeed", (rb.velocity.y));
        //Box Overlap Ground Check
        Vector2 boxCenter = new Vector2(transform.position.x + charCollision.offset.x, transform.position.y + -(playerSize.y + boxSize.y - 0.01f) + charCollision.offset.y);
        grounded = Physics2D.OverlapBox(boxCenter, boxSize, 0f, groundedLayers) != null;
        animator.SetBool("Grounded", grounded);


        //Move Character
        if (!isSliding)
        {
            rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        }

        //Jump
        if (jumped == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("Jumping!");

            jumped = false;
        }

        // Detect if character sprite needs flipping.
        if (horizInput > 0 && !facingRight)
        {

            FlipSprite();
        }
        else if (horizInput < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    void Update()
    {
        //Debug.Log(currentjumpCount);
        if (grounded)
        {
            currentjumpCount = maxJumps;
        }

        //Input for jumping ***Multi Jumping***
        if (Input.GetButtonDown("Jump") && currentjumpCount > 1)
        {
            jumped = true;
            currentjumpCount--;

            if (currentjumpCount == 1 && !grounded)
            {
                animator.SetTrigger("JumpAgain");
            }

            Debug.Log("Should jump");


        }
        if (Input.GetMouseButtonDown(1) && isSliding == false)
        {
            Debug.Log("Test");
            CharacterSlide();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && isCrouching == false && isSliding == false)
        {
            speed = runSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = originalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching == false)
        {
            //Debug.Log("Test");
            speed = crouchSpeed;
            isCrouching = true;
            animator.SetBool("IsCrouching", true);
            
        } else if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching == true)
        {
            speed = originalSpeed;
            animator.SetBool("IsCrouching", false);
            isCrouching = false;
            Debug.Log(isCrouching);
        }



        //Get Player input 
        horizInput = Input.GetAxis("Horizontal");
    }

    // Flip Character Sprite
    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void CharacterSlide()
    {
        isSliding = true;
        animator.SetBool("Dashing", true);
        if (facingRight)
        {
            rb.AddForce(Vector2.right * slideSpeed);

        }
        else
        {
            rb.AddForce(Vector2.left * slideSpeed);
        }

        StartCoroutine(CancelSlide());

        if (!isSliding)
        {
            //Move Character
            rb.velocity = new Vector2(horizInput * speed * Time.fixedDeltaTime, rb.velocity.y);
        }

        if (jumped == true && !isSliding)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("Jumping!");

            jumped = false;
        }




        IEnumerator CancelSlide()
        {
            yield return new WaitForSeconds(slideDuration);
            animator.SetBool("Dashing", false);
            isSliding = false;
        }

    }

    
}
