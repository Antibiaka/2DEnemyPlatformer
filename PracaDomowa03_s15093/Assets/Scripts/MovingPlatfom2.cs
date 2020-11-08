using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfom2 : MonoBehaviour
{
    float dirX, speed = 3f;
    bool limitR = true;
    float limit;
    
    // Start is called before the first frame update
    void Start()
    {
        limit = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < (limit - 5f))
        {
            limitR = true;
        }
        if (transform.position.y > (limit + 5f))
        {
            limitR = false;
        }

        if (limitR)
        {
            transform.position = new Vector2(transform.position.x , transform.position.y + speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - speed * Time.deltaTime);
        }
    }
}
