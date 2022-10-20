using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyV1 : MonoBehaviour
{
    private bool hit;
    public float resistDuration;

    SpriteRenderer sr;
    public Rigidbody2D rb;
    public GameObject roofchecking;
    [SerializeField] bool isSpriteFacingRight;
    [SerializeField] float movementSpeed;
    [SerializeField] Transform groundCheckPos;
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] Vector2 edgeCheckOffset;
    private Vector2 edgeCheckPos;
    private Vector2 edgeCheckSize;
    private Vector2 groundCheckSize;
    private bool edgeCheck;
    private bool groundCheck;
    //public bool wallCheck;
    //public bool roofCheck;
    private bool jumping;
    private float direction;
    public AudioSource punch;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        roofchecking.GetComponent<WallJumper>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        if (isSpriteFacingRight == false)
        {
            
            direction = -1;
        } else
        {
            direction = 1;
        }

        edgeCheckSize = new Vector2(0.5f, 0.5f);
        groundCheckSize = new Vector2(0.25f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        edgeCheckPos = new Vector2(transform.position.x + direction, transform.position.y - edgeCheckOffset.y);

        edgeCheck = Physics2D.OverlapBox(edgeCheckPos, edgeCheckSize, 0, collisionLayer);
        groundCheck = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, collisionLayer);

        
        GameObject enemyRoof = roofchecking;


        if (edgeCheck == true && groundCheck == true && enemyRoof.GetComponent<WallJumper>().roofCheck == true)
        {
            ChangeDirection();
        }
        
        else if (edgeCheck == true && groundCheck == true && enemyRoof.GetComponent<WallJumper>().roofCheck == false)
        {
            if (jumping == false)
            {
                Jump();
                StartCoroutine(Waitjump());
            }
        }

        //Debug.Log("Walls are" + wallCheck);
        //Debug.Log("Roof is" + roofCheck);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {


            if (other.GetComponent<PlayerHealth>() != null)
            {
                if (hit == false)
                {
                    Debug.Log("hit");
                    other.GetComponent<PlayerHealth>().TakeDamage(35);
                    punch.Play();
                    ChangeDirection();
                    hit = true;
                    StartCoroutine(WaitHit());
                }
                
            }
        }

        /*if (other.tag == "Wall")
        {
            
           wallCheck = true;



        }
        else
        {
            wallCheck = false;
        }

        if (other.tag == "Roof")
        {

            roofCheck = true;



        }
        else
        {
            roofCheck = false;
        }*/
    }

    /*public void WallCheckerFunction()
    {
        if(wallCheck == true)
        {
            wallCheck = false;
        }
        if (wallCheck == false)
        {
            wallCheck = true;
        }
    }
    
    public void RoofCheckerFunction(bool roofCheck)
    {
        if (roofCheck == true)
        {
            roofCheck = false;
        }
        if (roofCheck == false)
        {
            roofCheck = true;
        }
    }
    */
    void Jump()
    {
        jumping = true;
        if (jumping == true)
        {
            rb.AddForce(Vector2.up * 600f);
            

        }
       
        
    }
    
    IEnumerator Waitjump()
    {
        yield return new WaitForSeconds(0.1f);
        jumping = false;
    }

    IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(resistDuration);
        hit = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * movementSpeed, rb.velocity.y);

    }

    void ChangeDirection()
    {
        if(direction == 1)
        {
            direction = -1;
            sr.flipX = false;
        }
        else
        {
            direction = 1;
            sr.flipX = true;
        }
    }

    void OnDrawGizmos()
    {
        if (edgeCheck == true)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(edgeCheckPos, edgeCheckSize);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(edgeCheckPos, edgeCheckSize);
        }

        if (groundCheck == true)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);
        }

    }

}
