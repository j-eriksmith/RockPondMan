using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Script : MonoBehaviour {

    public GameObject[] list_of_moveing;
    public Button[] rocks;
    private Vector2[] movement_vectors;
	
    void OnEnable()
    {
        movement_vectors = new Vector2[list_of_moveing.Length];
        Time.timeScale = 0;
        for (int i = 0; i < list_of_moveing.Length; ++i)
        {
            Rigidbody2D rb2 = list_of_moveing[i].GetComponent<Rigidbody2D>();
            movement_vectors[i] = rb2.velocity;
            rb2.velocity = Vector2.zero;
        }
        for (int i = 0; i < rocks.Length; ++i)
            rocks[i].enabled = false;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
        for (int i = 0; i < movement_vectors.Length; ++i)
            list_of_moveing[i].GetComponent<Rigidbody2D>().velocity = movement_vectors[i];
        for (int i = 0; i < rocks.Length; ++i)
            rocks[i].enabled = false;
    }
}
