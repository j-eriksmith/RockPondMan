using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item : MonoBehaviour {

    public GameObject ripple_prefab;
    public int num_of_differenet_items;
    public Rock_Attributes[] num_of_items;
    private Rock_Attributes cur_item;

    // Use this for initialization
    void Start()
    {
        cur_item = num_of_items[0];
    }

// Update is called once per frame
void Update () {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cur_item.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);

        if (Input.GetMouseButtonDown(1))
            create_ripple(mouse_pos.x, mouse_pos.y, cur_item);

    }


void create_ripple(float mouseX, float mouseY, Rock_Attributes cur_rock)
    {
        GameObject ripple = Transform.Instantiate<GameObject>(ripple_prefab);
        Ripple_Physics rp = ripple.GetComponent<Ripple_Physics>();
        rp.force = cur_rock.force;
        rp.increase_speed = cur_rock.ripple_speed;
        rp.initialized = true;
        ripple.transform.position = new Vector3(mouseX, mouseY, 0);
        
    }
}
