using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Controller : MonoBehaviour {

    public AudioSource music;
	// Use this for initialization
	void OnEnable () {
        if (!music.isPlaying)
            music.Play();
        else
        {
            print("start");
            music.time = PlayerPrefs.GetFloat("music_time");
            print(music.time);
        }
	}

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
