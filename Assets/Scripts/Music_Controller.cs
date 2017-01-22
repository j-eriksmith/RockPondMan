using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Controller : MonoBehaviour {

    public AudioSource music;
	// Use this for initialization
	void Awake () {
        if (!music.isPlaying)
            music.Play();

        DontDestroyOnLoad(this.gameObject);
        
	}

}
