using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_to_level_selection : MonoBehaviour {

	// Use this for initialization


	public void LoadOnClick(int level)
	{
		
		Application.LoadLevel (level);
	}

}
