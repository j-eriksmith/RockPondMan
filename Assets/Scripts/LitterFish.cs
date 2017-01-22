using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterFish : MonoBehaviour {
    public float cycleTime = 3f;
    private float underwaterTransparency = 0.3f;
    private Color currentTransparency;
    private bool aboveWater = true;

    void Start() {
        StartCoroutine(FishBobbing(underwaterTransparency, cycleTime));
    }

    void Update() {
	}

    IEnumerator FishBobbing(float aValue, float aTime) {
        for(;;)
        {
            yield return new WaitForSeconds(aTime);
            StartCoroutine(ChaseAlpha(!aboveWater, aTime / 3.0f));
        }
    }

    IEnumerator ChaseAlpha(bool desiredState, float overTime) {
        float desiredAlpha = desiredState ? 1.0f : underwaterTransparency;
        float startAlpha = gameObject.GetComponent<SpriteRenderer>().color.a;
        float accumulator = 0.0f;

        if(!desiredState) {
            aboveWater = false;
        }

        while(accumulator < overTime) {
            
            float lerpAlpha = Mathf.Lerp(startAlpha, desiredAlpha, accumulator / overTime);
            Color newColor = new Color(1, 1, 1, lerpAlpha);
            gameObject.GetComponent<SpriteRenderer>().color = newColor;

            yield return 0;
            accumulator += Time.deltaTime;
        }
        aboveWater = desiredState;
    }

    void OnTriggerStay2D(Collider2D c) {
        if(!aboveWater) {
            return;
        }

        if(c.gameObject.tag == "Trash") {
            c.gameObject.SetActive(false);
        }
    }

    /*
    IEnumerator FishBobbing() {
        while(currentTransparency.a <= 1) {
            currentTransparency.a += incrementalValue;
            gameObject.GetComponent<SpriteRenderer>().color = currentTransparency;
            new WaitForSeconds(0.5f);
        }
        print("Done");
        yield return new WaitForSeconds(cycleTime);
        while(currentTransparency.a >= underwaterTransparency) {
            currentTransparency.a -= incrementalValue;
            gameObject.GetComponent<SpriteRenderer>().color = currentTransparency;
            new WaitForSeconds(0.5f);
        }

    
    IEnumerator FishBobbing() {
        if(currentTransparency.a <= 1) {
            for(float i = underwaterTransparency; i <=1f; i += 0.1f) {
                currentTransparency.a = i;
                gameObject.GetComponent<SpriteRenderer>().color = currentTransparency;
            }
            yield return new WaitForSeconds(3f);
        }
        if(currentTransparency.a >= underwaterTransparency) {
            for(float i = 1f; i <= underwaterTransparency; i -= 0.1f) {
                currentTransparency.a = i;
                gameObject.GetComponent<SpriteRenderer>().color = currentTransparency;
            }
            yield return new WaitForSeconds(3f);
        }
        
        for(float i = underwaterTransparency; i <= 1f; i += 0.1f) {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, i);
        }
        yield return new WaitForSeconds(cycleTime);
        for(float i = 1f; i <= underwaterTransparency; i -= 0.1f) {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, i);
        }
        */
}
