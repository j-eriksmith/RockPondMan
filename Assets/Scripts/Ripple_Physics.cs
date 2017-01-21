using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple_Physics : MonoBehaviour {

    private GameObject[] pushed_objects;
    public float decrease_speed;
    public float increase_speed;
    public float force;
    public bool initialized = false;

    void Start()
    {
        pushed_objects = new GameObject[0];
    }

    void Update()
    {
        if(initialized)
        {
            if (force > 0)
            {
                transform.localScale += new Vector3(increase_speed, increase_speed, 0);
                force -= decrease_speed;
            }
            else
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        for(int i = 0; i < pushed_objects.Length; ++i)
        {
            if (c.gameObject == pushed_objects[i])
                return;
        }
        //find angle between game object and point of collision
        float angle = Vector3.Angle(gameObject.transform.position, c.transform.position);
        print(angle);
        
        //Add force in given direction multiplied by the force of the wave at that moment
        c.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle) * force, Mathf.Sin(angle) * force));
    }
}
