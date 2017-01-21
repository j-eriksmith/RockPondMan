using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple_Physics : MonoBehaviour {

    private CircleCollider2D collider;
    private GameObject[] pushed_objects;
    public float decrease_speed;
    public float increase_speed;
    public float force;
    public bool initialized = false;

    void Start()
    {
        collider = transform.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(initialized)
        {
            if (force > 0)
            {
                collider.radius += increase_speed;
                force -= decrease_speed;
            }
            else
                Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        for(int i = 0; i < pushed_objects.Length; ++i)
        {
            if (c.gameObject == pushed_objects[i])
                return;
        }
        //find angle between game object and point of collision
        Vector3 heading = gameObject.transform.position - c.transform.position;
        
        //Add force in given direction multiplied by the force of the wave at that moment
        c.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(heading.normalized.x) * force, Mathf.Sin(heading.normalized.y) * force));
    }
}
