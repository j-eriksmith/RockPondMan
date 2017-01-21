using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Item : MonoBehaviour {

    public GameObject ripple_prefab;
    public int num_of_differenet_items;
    public int[] num_of_items;
    public GameObject[] list_of_items;
    private GameObject cur_item;
    private int choosen_item;

    // Use this for initialization
    void Start()
    {
        //Enter the number of each item you want in here
        choosen_item = 0;
        cur_item = Instantiate(list_of_items[choosen_item]);
    }

// Update is called once per frame
void Update () {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cur_item.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            if(num_of_items[choosen_item] > 0)
            {
                StartCoroutine(drop_rock(mouse_pos.x, mouse_pos.y, cur_item.gameObject));
                num_of_items[choosen_item]--;
                cur_item = null;
            }
        }
        //JUST FOR TESTING CHANGE THIS TO ALLOW BUTTONS TO CHANGE ROCK
        if(cur_item == null)
            cur_item = Instantiate(list_of_items[choosen_item]);

    }


void create_ripple(float mouseX, float mouseY, Rock_Attributes cur_rock)
    {
        GameObject ripple = Instantiate(ripple_prefab);
        Ripple_Physics rp = ripple.GetComponent<Ripple_Physics>();
        rp.force = cur_rock.force;
        rp.increase_speed = cur_rock.ripple_speed;
        rp.initialized = true;
        ripple.transform.position = new Vector3(mouseX, mouseY, 0);
        
    }

IEnumerator drop_rock(float mouseX, float mouseY, GameObject rock)
    {
        for (int i = 0; i < 50; ++i)
        {
            rock.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        create_ripple(mouseX, mouseY, rock.GetComponent<Rock_Attributes>());
        Destroy(rock);
    }
}
