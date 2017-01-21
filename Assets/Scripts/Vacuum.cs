using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour {
    public GameObject[] pulled_objects;
    private int cur_index = 0;
    public float speed;

    void Start () {
        pulled_objects = new GameObject[20];
    }

	void Update () {
        for (int i = 0; i < cur_index; ++i)
        {
            Vector2 vacuumPosition = gameObject.transform.position;
            pulled_objects[i].transform.position = Vector2.MoveTowards(pulled_objects[i].transform.position, vacuumPosition, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        for (int i = 0; i < cur_index; i++)
        {
            if (c.gameObject == pulled_objects[i])
                return;
        }
        if(c.gameObject.tag == "Trash"){
            pulled_objects[cur_index] = c.gameObject;
            cur_index++;
        }
    }

    // Returns the number objects pulled in by vacuum.
    public int ObjectsPulled()
    {
        return (pulled_objects.Length);
    }
}
