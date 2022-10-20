using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;



    private Transform player;
    private Vector3 target;

    protected ControllerAlt owner;
    protected WeaponAlt weapon;
    protected Transform firePoint;

    public float damage;
    private Vector2 playerPos;
    private Vector2 curPos;
    private Vector2 lastPos;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);

        transform.up = target - transform.position;

        //transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
    }
    void Update()
    {
        curPos = transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, 5f * Time.deltaTime);
        if (curPos == lastPos)
        {
            Destroy(gameObject);
        }
        lastPos = curPos;
    }

    public virtual void InitProjectile(GameObject ownerGO, WeaponAlt weapon, Transform firePoint)
    {
        owner = ownerGO.GetComponent<ControllerAlt>();

        if (ownerGO.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy Projectile");
        }

        this.weapon = weapon;
        this.firePoint = firePoint;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger == true) return;
        ControllerAlt controller = other.gameObject.GetComponent<ControllerAlt>();
        if (other.tag == "Player")
        {
            if (controller != null)
            {
                if (owner != controller)
                {
                    controller.TakeDamage(damage, owner);
                }
            }

            Destroy(this.gameObject);
        }
        else if (other.tag != "Player")
        {
            Destroy(this.gameObject);
        }


        /*if (other.isTrigger == true) return;

        ControllerAlt controller = other.gameObject.GetComponent<ControllerAlt>();

        if (controller != null)
        {
            if (owner != controller)
            {
                controller.TakeDamage(damage, owner);
                Destroy(this.gameObject);
                //if (GetComponent<CinemachineImpulseSource>() != null)
                //GetComponent<CinemachineImpulseSource>().GenerateImpulse();


                //if (hitFX != null) Instantiate(hitFX, transform.position, transform.rotation);
            }
        }
        else
        {
            Destroy(this.gameObject);
            //if (hitFX != null) Instantiate(hitFX, transform.position, transform.rotation);
        }
        if (other.tag != "Player")
        {
            Destroy(this.gameObject);
        }*/
    }


}

