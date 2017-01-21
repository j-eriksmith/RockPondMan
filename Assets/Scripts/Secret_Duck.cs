using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Secret_Duck : MonoBehaviour {

    public AudioSource duck_noise;
    public string level_to_unlock;
    public Canvas canvas;
    public Text unlock_duck;
	
    void Start()
    {
        StartCoroutine(quack());
    }

	// Update is called once per frame
	void OnMouseUp () {
        PlayerPrefs.SetInt(level_to_unlock, 1);
        Text duck_text = Instantiate(unlock_duck, canvas.transform);
        duck_text.transform.position = Vector3.zero;
        duck_text.text = "Duck Level " + level_to_unlock + " \nUnlocked!";
        Destroy(gameObject);
	}

    IEnumerator quack()
    {
        while(true)
        {
            yield return new WaitForSeconds(7f);
            duck_noise.pitch = (Random.Range(0.9f, 1.1f));
            duck_noise.Play();
        }
    }
}
