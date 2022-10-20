using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Pathfinding
{
    using Pathfinding.Util;
    public class Scanning : MonoBehaviour
    {
        public int distance;
        public GameObject gunObject;
        public AIPath otherObject;
        private GameObject playerObject;
        private bool inCircle;
        private float waitTime;
        public float startWaitTime;

        public Transform[] moveSpots;
        private int randomSpots;


        void Start()
        {
            inCircle = false;
            playerObject = GameObject.FindGameObjectWithTag("PlayerLOS");
            gunObject.SetActive(false);
            otherObject.canMove = false;

            Physics2D.queriesStartInColliders = false;

            waitTime = startWaitTime;
            randomSpots = Random.Range(0, moveSpots.Length);
        }


        void Update()
        {
            // transform.Rotate();
            Vector3 playerPos = playerObject.transform.position;

            if (inCircle)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPos - transform.position, distance);

                //If the collider of the object hit is not NUll
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("PlayerLOS"))
                    {

                        Debug.Log("seeking player");
                        Debug.Log("Hitting");
                        gunObject.SetActive(true);
                        otherObject.canMove = true;
                    }
                    else
                    {
                        Debug.Log("Not Hitting");
                        gunObject.SetActive(false);
                        otherObject.canMove = false;
                        Patrol();
                    }
                }

                //Method to draw the ray in scene for debug purpose
                Debug.DrawRay(transform.position, playerPos - transform.position, Color.red);


                /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, playersPos, distance);


                if (hitInfo.collider != null)
                {

                    //Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                    Debug.DrawLine(transform.position, playersPos, Color.red);
                    if (hitInfo.collider.CompareTag("Player"))
                    {
                        Debug.Log("Hitting");
                        //Destroy(hitInfo.collider.gameObject);
                        otherObject.GetComponent<agent>().enabled = true;
                        otherObject.GetComponent<Patrol>().enabled = false;
                        //hitInfo.transform.LookAt(playerObject.transform.position);

                    }
                    else
                    {
                        Debug.Log("Not Hitting");
                        otherObject.GetComponent<agent>().enabled = false;
                        otherObject.GetComponent<Patrol>().enabled = true;
                    }
                }
                else
                {
                    otherObject.GetComponent<agent>().enabled = false;
                    Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.blue);
                }*/
            }
            else if (!inCircle)
            {
                gunObject.SetActive(false);
                otherObject.canMove = false;
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, otherObject.maxSpeed * Time.deltaTime);

                Debug.Log("Not In Circle");


                if (Vector2.Distance(transform.position, moveSpots[randomSpots].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        //Debug.Log("finding new point");
                        randomSpots = Random.Range(0, moveSpots.Length);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        //Debug.Log("waiting at point");

                        waitTime -= Time.deltaTime;
                    }
                }
            }



        }

        

        public void Patrol()
        {

            Debug.Log("In Patrolling function");
            

            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, otherObject.maxSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpots].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpots = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }


        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "PlayerLOS")
            {
                inCircle = true;
            }

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "PlayerLOS")
            {
                inCircle = false;
            }
        }

    }
}