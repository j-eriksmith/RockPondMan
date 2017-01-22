using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour {

    public int need_to_collect;
    public VacuumCollision vc;
    public start_to_level_selection level_select_script;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (need_to_collect == vc.return_items_caught())
            StartCoroutine(Win_Level());
	}


    IEnumerator Win_Level()
    {
        yield return new WaitForSeconds(1);
        level_select_script.LoadOnClick(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
