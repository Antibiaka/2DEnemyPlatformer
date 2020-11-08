using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    
    float dirX , speed = 3f;
    bool limitR = true;
    //private Transform startPos, endpos;

    float limit;

    // Start is called before the first frame update

    void Start()
    {
        limit = transform.position.x;
        // nextPos = startPos.position;
        //Debug.Log("pos is " + limit);
    }

    void Update()
    {

        if (transform.position.x < (limit-10f) )
        {
            limitR = true;
        }
        if (transform.position.x > (limit + 10f))
        {
            limitR = false;
        }

        if (limitR)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

    }
    // Update is called once per frame

        //if (transform.position == pos1.position)
        //{
        //    nextPos = pos2.position;
        //}
        //if (transform.position == pos2.position)
        //{
        //    nextPos = pos1.position;
        //}
        //transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawLine(pos1.position, pos2.position);
    //}
        //Vector3 pos1 = GameObject.Find("PosMax").transform.position;
        //Vector3 pos2 = GameObject.Find("PosMin").transform.position;
        //Debug.Log("pos is " + transform.position.x);
}
