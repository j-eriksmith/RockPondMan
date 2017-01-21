﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple_Physics : MonoBehaviour {

    private GameObject[] pushed_objects;
    public float decrease_speed;
    public float increase_speed;
    public float force;
    public float max_vel;
    public bool initialized = false;
    private int cur_index = 0;

    void Start()
    {
        pushed_objects = new GameObject[20];
    }

    void Update()
    {
        if(initialized)
        {
            if (force > 0)
            {
                transform.localScale += new Vector3(increase_speed, increase_speed, 0);
                force -= decrease_speed;
                for(int i = 0; i <cur_index; ++i)
                {
                    //find angle between game object and point of collision
                    Vector2 angle = -(gameObject.transform.position - pushed_objects[i].transform.position);

                    //Add force in given direction multiplied by the force of the wave at that moment
                    if (pushed_objects[i].GetComponent<Rigidbody2D>().velocity.magnitude < max_vel)
                        pushed_objects[i].GetComponent<Rigidbody2D>().AddForce((new Vector2(angle.x, angle.y)).normalized * force * Time.deltaTime);
                }
            }
            else
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        for(int i = 0; i < cur_index; ++i)
        {
            if (c.gameObject == pushed_objects[i])
                return;
        }
        pushed_objects[cur_index] = c.gameObject;
        cur_index++;

    }
}
