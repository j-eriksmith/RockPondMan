using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCollision : MonoBehaviour
{

	void Start()
    {
		
	}

	void Update()
    {
        
	}

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Trash")
        {
            c.gameObject.SetActive(false);
        }
    }
}
