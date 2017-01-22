using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Unlock : MonoBehaviour {

	public GameObject[] button;


	// Use this for initialization
	void Start () {


		if (PlayerPrefs.GetInt ("level_1") == 1)
			button [0].SetActive (true);

		if (PlayerPrefs.GetInt ("level_2") == 1)
			button [1].SetActive (true);

		if (PlayerPrefs.GetInt ("level_3") == 1)
			button [2].SetActive (true);
	}
}
