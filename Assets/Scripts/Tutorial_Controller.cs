using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Controller : MonoBehaviour {

    public Text[] text_to_show;
    public GameObject eventsystem;
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
            //yield return new WaitForSeconds(4);
            string text_to_type = text_to_show[i].text;
            text_to_show[i].text = "";
            for (int j = 0; j < text_to_type.Length; ++j)
            {
                text_to_show[i].text += text_to_type[j];
                yield return new WaitForSeconds(0.08f);
                if (Input.GetKey(KeyCode.Space))
                {
                    text_to_show[i].text = text_to_type;
                    break;
                }
            }
            for(int j = 0; j < 100; j++)
            {
                yield return new WaitForSeconds(0.04f);
                if (Input.GetKey(KeyCode.Space))
                {
                    break;
                }
            }
            text_to_show[i].gameObject.SetActive(false);
        }
        while (sr.color.a > 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.01f);
            yield return new WaitForSeconds(0.0001f);
        }
        eventsystem.SetActive(true);
        Destroy(gameObject);
    }

}
