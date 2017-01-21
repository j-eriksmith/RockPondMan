using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaMovement : MonoBehaviour{
    public GameObject location;

    private bool hit;

    public float speed;
    
	void Start ()
    {
        hit = false;
    }

	void Update ()
    {
        if (hit == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, location.transform.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Ripple")
        {
            hit = true;
        }
    }
}
