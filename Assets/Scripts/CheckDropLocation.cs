using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDropLocation : MonoBehaviour {

    public static bool canDrop = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseEnter() {
        print("test1");
        canDrop = true;
    }

    void OnMouseExit() {
        print("test2");
        canDrop = false;
    }

}
