﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime = 0.1f;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKey(KeyCode.S)) {
            if (waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;

            } else {
                waitTime -= Time.deltaTime;
            }
        }
        if( Input.GetKey(KeyCode.W)) {
            effector.rotationalOffset = 0;
        }
    }
}
