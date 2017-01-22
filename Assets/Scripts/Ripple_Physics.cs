using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple_Physics : MonoBehaviour {

    private GameObject[] pushed_objects, list_of_ripples;
    private SpriteRenderer[] ripples_sprites;
    private int num_ripples;
    public GameObject other_ripple;
    public float decrease_speed;
    public float increase_speed;
    public float force;
    public float max_vel;
    public bool initialized = false;
    private int cur_index = 0;
    private bool rippling = false;

    void Start()
    {
        pushed_objects = new GameObject[20];
        list_of_ripples = new GameObject[5];
        ripples_sprites = new SpriteRenderer[5];
        list_of_ripples[0] = gameObject;
        ripples_sprites[0] = gameObject.GetComponent<SpriteRenderer>();
        num_ripples = 1;
    }

    void Update()
    {
        if(!rippling)
        {
            StartCoroutine(Add_Ripples());
            rippling = true;
        }

        if(initialized)
        {
            for(int i = 1; i < num_ripples; ++i)
            {
                list_of_ripples[i].transform.localScale += new Vector3(increase_speed / 10, increase_speed / 10, 0);
                //there is no index 0 since the first object is the empty object that is the collider but no sprite
                ripples_sprites[i].color = new Color(ripples_sprites[i].color.r, ripples_sprites[i].color.g, ripples_sprites[i].color.b, ripples_sprites[i].color.a - 0.015f);
                if (i == num_ripples - 1 && ripples_sprites[i].color.a <= 0)
                    Destroy(gameObject);
            }
            if (force > 0)
            {
                list_of_ripples[0].transform.localScale += new Vector3(increase_speed / 10, increase_speed / 10, 0);


                force -= decrease_speed;
                for (int i = 0; i < cur_index; ++i)
                {
                    //find angle between game object and point of collision
                    Vector2 angle = -(gameObject.transform.position - pushed_objects[i].transform.position);

                    //Add force in given direction multiplied by the force of the wave at that moment
                    if (pushed_objects[i].GetComponent<Rigidbody2D>().velocity.magnitude < max_vel)
                        pushed_objects[i].GetComponent<Rigidbody2D>().AddForce((new Vector2(angle.x, angle.y)).normalized * force * Time.deltaTime);
                }
            }
            
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

    IEnumerator Add_Ripples()
    {
        for(int i = 1; i < 5; ++i)
        {
            yield return new WaitForSeconds(0.3f);
            list_of_ripples[num_ripples] = Instantiate(other_ripple, gameObject.transform);
            list_of_ripples[num_ripples].transform.localPosition = (new Vector3(0, 0, 0));
            ripples_sprites[num_ripples] = list_of_ripples[num_ripples].GetComponent<SpriteRenderer>();
            num_ripples++;
        }
        //yield return new WaitForSeconds(1);
        // Play the animation to do the water going up effect when the rock hits
    }
}
