using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDoorInteract : MonoBehaviour
{

    public bool isDoor;
    //private SpriteRenderer rend;
    public Image EKey;

    //[SerializeField]
    //private Color colorToTurnInto = Color.gray;

    // Start is called before the first frame update
    private void Start()
    {
        EKey.gameObject.SetActive(false);
        //rend = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isDoor && Input.GetKeyDown(KeyCode.E))
        {

            //rend.material.color = colorToTurnInto;
            //rend.sortingOrder = 0;
            
            //Physics2D.IgnoreLayerCollision(8, 9, true);
            Debug.Log("Enter Door");
            SceneManager.LoadScene("Warehouse");
        }

    }
        void OnTriggerEnter2D(Collider2D other)
        {

            if (other.gameObject.tag == "Door")
            {
                EKey.gameObject.SetActive(true);
                isDoor = true;
            }

        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Door")
            {
                EKey.gameObject.SetActive(false);
                isDoor = false;
            }
        }
}
