using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranahMovement : MonoBehaviour{
    public GameObject location;

    private bool hit;
    
	// Use this for initialization
	void Start ()
    {
        hit = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hit == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, location.transform.position, 30 * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "ripple")
        {
                hit = true;
        }
    }
}
