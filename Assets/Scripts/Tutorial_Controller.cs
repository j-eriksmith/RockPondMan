using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Controller : MonoBehaviour {

    public Text[] text_to_show;
    private SpriteRenderer sr;
	void Start () {
        StartCoroutine(start_tutorial());
        sr = GetComponent<SpriteRenderer>();
	}

    IEnumerator start_tutorial()
    {
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < text_to_show.Length; ++i)
        {
            text_to_show[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(4);
            text_to_show[i].gameObject.SetActive(false);
        }
        while (sr.color.a > 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.01f);
            yield return new WaitForSeconds(0.0001f);
        }
        Destroy(gameObject);
    }

}
