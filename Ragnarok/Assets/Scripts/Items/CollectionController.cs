using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item
{
    public string name;

    public string description;

    public Sprite itemImage;
}

public class CollectionController : MonoBehaviour
{

    public Item item;

    public float healthChange;

    public float moveChange;

    public float fireChange;

    public float fireSize;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.itemImage;
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ScoreSystem.Instance.AddScore(5);
            HealthComponent.HaveHealth(healthChange);
            PlayerController.MoveSpeedChange(moveChange);
            BulletController.FireRateChange(fireChange);
            BulletController.FireSizeChange(fireSize);
            Destroy(gameObject);
        }
    }
}
