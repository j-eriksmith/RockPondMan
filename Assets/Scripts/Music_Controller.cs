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
<<<<<<< HEAD
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
=======
        else
        {
            print("start");
            music.time = PlayerPrefs.GetFloat("music_time");
            print(music.time);
        }
	}
>>>>>>> origin/master

    void Update()
    {
        PlayerPrefs.SetFloat("music_time", music.time);
        print(music.time);
    }
	
    void OnDisable()
    {
        print("end");
        PlayerPrefs.SetFloat("music_time", music.time);
        print(music.time);
    }
}
