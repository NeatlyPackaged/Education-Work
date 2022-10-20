using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow2DCamera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float timeOffset;

    [SerializeField]
    Vector2 posOffset;


    [SerializeField]
    float leftLimit;
    
    [SerializeField]
    float rightLimit;
    
    [SerializeField]
    float bottomLimit;

    [SerializeField]
    float topLimit;

    
    
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //camera start position
        Vector3 startPos = transform.position;
        //players current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //this is how you lerp and move the camera towards the player
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //This is how you use smooth dampening
        //transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        //This is to have a border for where the camera can go
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

        //Camera Moving down
        if(Input.GetKey(KeyCode.DownArrow))
        {
            endPos.x += posOffset.x;
            endPos.y += posOffset.y - 5;
            endPos.z = -10;
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
            transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );
            
        }
        //Camera Moving Up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            endPos.x += posOffset.x;
            endPos.y += posOffset.y + 3;
            endPos.z = -10;
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
            transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

        }
        //Camera Moving Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            endPos.x += posOffset.x - 6;
            endPos.y += posOffset.y - 1;
            endPos.z = -10;
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
            transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

        }
        //Camera Moving Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            endPos.x += posOffset.x + 6;
            endPos.y += posOffset.y - 1;
            endPos.z = -10;
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
            transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

        }


    }

    void OnDrawGizmos()
    {
        // draw a box around our camera boundary
        Gizmos.color = Color.red;
        // top boundary line 
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        // right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        // Bottom boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        // left boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }



}
