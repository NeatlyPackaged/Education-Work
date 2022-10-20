using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    
    Wander,

    Follow,

    Die, 

    Attack
};
public enum EnemyType
{
    Melee,
    Ranged
};

public class EnemyController : MonoBehaviour
{

    GameObject player;

    public GameObject bulletPrefab;

    public EnemyState currState = EnemyState.Idle;
    
    public EnemyType enemyType;
    
    public float range;
    
    public float speed;
    
    public float attackingRange;
    
    public float bulletSpeed;
    
    public bool notInRoom = false;
    
    private bool chooseDir = false;
    
    private bool dead = false;
    
    private bool attackcool = false;
    
    public float cooldown;
    
    private Vector3 randomDir;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    // Update is called once per frame


    void Update()
    {
        switch (currState)
        {
            case (EnemyState.Wander):
                Wander();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
                Death();
                break;
            case (EnemyState.Attack):
                Attack();
                break;
        }

        if (!notInRoom)
        {
            if (IsPlayerInRange(range) && currState != EnemyState.Die)
            {
                currState = EnemyState.Follow;
            }
            else if (!IsPlayerInRange(range) && currState != EnemyState.Die)
            {
                currState = EnemyState.Wander;
            }
            if(Vector3.Distance(transform.position, player.transform.position) <= attackingRange)
            {
                currState = EnemyState.Attack;
            }
        }
        else
        {
            currState = EnemyState.Idle;
        }
    }

    


    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    void Wander()
    {
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    void Attack()
    {
        if (!attackcool)
        {
            switch (enemyType)
            {
                case (EnemyType.Melee):
                    HealthComponent.TakeDamage(20);
                    StartCoroutine(Cooldown());
                    break;
                case (EnemyType.Ranged):
                    if(dead == false)
                    {
                        
                        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                        bullet.GetComponent<BulletController>().isEnemyBullet = true;
                        bullet.GetComponent<BulletController>().GetPlayer(player.transform);
                        //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                        StartCoroutine(Cooldown());
                    }
                    
                    break;
            }
        }
        
    }

    private IEnumerator Cooldown()
    {
        attackcool = true;
        yield return new WaitForSeconds(cooldown);
        attackcool = false;
    }

    void Death()
    {
        
        dead = true;
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
        Destroy(gameObject);
    }
}