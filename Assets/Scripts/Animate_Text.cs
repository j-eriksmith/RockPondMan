using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate_Text : MonoBehaviour {

    public float speed;
    private bool not_started = true;
	
    void Start()
    {
        transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    }

	// Update is called once per frame
	void Update () {
        transform.localPosition = Vector3.zero;
        if(not_started)
        {
            StartCoroutine(Animate());
            not_started = false;
        }
	}


    IEnumerator Animate()
    {
        GetComponent<AudioSource>().Play();
        while (transform.localScale.x < 1f && transform.localScale.y < 1f)
        {
            transform.localScale += new Vector3(speed, speed, 0);
            yield return new WaitForSeconds(0.00001f);
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
