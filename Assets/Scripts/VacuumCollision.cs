using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCollision : MonoBehaviour
{
    private int items_caught = 0;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Trash")
        {
            items_caught++;
            c.gameObject.SetActive(false);
        }
    }

    public int return_items_caught()
    {
        return items_caught;
    }
}
