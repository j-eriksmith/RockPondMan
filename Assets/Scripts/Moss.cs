using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss : MonoBehaviour {
    public float dragIncrease;

	void Start() {
		
	}
	
	void Update() {
		
	}

    void OnTriggerEnter2D(Collider2D c) {
        if(c.gameObject.tag == "Trash") {
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            rb.drag += dragIncrease;
        }
    }

    void OnTriggerExit2D(Collider2D c) {
        if(c.gameObject.tag == "Trash") {
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            rb.drag -= dragIncrease;
        }
    }
}
