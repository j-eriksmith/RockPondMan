using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss : MonoBehaviour {
    public float dragIncrease;
    private Dictionary<GameObject, float> initialDrags = new Dictionary<GameObject, float>();

	void Start() {
        GameObject[] trashObjects = GameObject.FindGameObjectsWithTag("Trash");
        for(int i = 0; i < trashObjects.Length; i++) {
            float drag = trashObjects[i].GetComponent<Rigidbody2D>().drag;
            initialDrags.Add(trashObjects[i], drag);
        }
	}
	
	void Update() {
		
	}

    void OnTriggerEnter2D(Collider2D c) {
        if(c.gameObject.tag == "Trash") {
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            if(rb.drag == initialDrags[c.gameObject]) {
                rb.drag += dragIncrease;
            }
        }
    }

    void OnTriggerExit2D(Collider2D c) {
        if(c.gameObject.tag == "Trash") {
            Rigidbody2D rb = c.GetComponent<Rigidbody2D>();
            rb.drag = initialDrags[c.gameObject];
        }
    }
}
