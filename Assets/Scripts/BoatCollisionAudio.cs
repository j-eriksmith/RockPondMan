using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollisionAudio : MonoBehaviour {
    private AudioSource boatSound;

	void Start () {
        boatSound = gameObject.GetComponent<AudioSource>();
    }
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D c) {
        if(c.gameObject.tag == "Trash") {
            boatSound.pitch = Random.Range(0.8f, 1.2f);
            boatSound.Play();
        }
    }
}
