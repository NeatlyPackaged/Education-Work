using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float lifeTime;

    public bool isEnemyBullet = false;

    private Vector2 lastPos;

    private Vector2 curPos;
    
    private Vector2 playerPos;

    public float speed = 10f;

    private Rigidbody2D rb;

    private static float fireRate = 0.5f;

    private static float bulletSize = 0.5f;

    public static float FireRate { get => fireRate; set => fireRate = value; }
    public static float BulletSizeChange { get => bulletSize; set => bulletSize = value; }
    // Start is called before the first frame update

    void Awake()
    {
        speed = 10f;
        fireRate = 0.5f;
        bulletSize = 0.5f;
    }

    void Start()
    {
        speed = 10f;
        fireRate = 0.5f;
        bulletSize = 0.5f;
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(DeathDelay());
        if (!isEnemyBullet)
        {
            transform.localScale = new Vector2(bulletSize, bulletSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isEnemyBullet)
        {
            curPos = transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
            if (curPos == lastPos)
            {
                Destroy(gameObject);
            }
            lastPos = curPos;
        }
        else if (!isEnemyBullet)
        {
            rb.velocity = transform.right * speed;
        }
    }

    public void GetPlayer(Transform player)
    {
        playerPos = player.position;
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !isEnemyBullet)
        {
            if (other.GetComponent<EnemyHealth>() != null)
            {

                other.GetComponent<EnemyHealth>().TakeDamage(35);
            }

            Destroy(this.gameObject);
        }

        if (other.tag == "Player" && isEnemyBullet)
        {
            HealthComponent.TakeDamage(20);
            Destroy(gameObject);
        }

    }

    public static void FireRateChange(float rate)
    {
        fireRate -= rate;
    }

    public static void FireSizeChange(float size)
    {
        bulletSize += size;
    }
}