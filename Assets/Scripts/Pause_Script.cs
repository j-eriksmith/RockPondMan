using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Script : MonoBehaviour {

    public GameObject[] list_of_moveing;
    public Drop_Item di;
    private Vector2[] movement_vectors;
	
    void OnEnable()
    {
        movement_vectors = new Vector2[list_of_moveing.Length];
        for (int i = 0; i < list_of_moveing.Length; ++i)
        {
            Rigidbody2D rb2 = list_of_moveing[i].GetComponent<Rigidbody2D>();
            movement_vectors[i] = rb2.velocity;
            rb2.velocity = Vector2.zero;
            di.change_rock(-1);
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < movement_vectors.Length; ++i)
            list_of_moveing[i].GetComponent<Rigidbody2D>().velocity = movement_vectors[i];
    }
}
