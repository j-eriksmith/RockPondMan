using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Controller : MonoBehaviour {

    private static Music_Controller instance = null;
    public static Music_Controller Instance
    {
        get { return instance; }
    }



    public AudioSource music;
	// Use this for initialization
	void OnEnable () {
        if (!music.isPlaying)
            music.Play();
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

}
