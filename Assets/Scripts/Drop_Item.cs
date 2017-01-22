using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop_Item : MonoBehaviour {
	
	public Text[] num_rock_ui;
    public GameObject ripple_prefab;
    public AudioSource rock_sound;
    public int num_of_differenet_items;
    public int[] num_of_items;
    public GameObject[] list_of_items;
    private GameObject cur_item;
    private int choosen_item;
    private bool get_next_rock;

    // Use this for initialization
    void Start()
    {
        //Enter the number of each item you want in here
        choosen_item = -1;
        cur_item = null;
		for (int i = 0; i < num_of_items.Length; i++) {
			num_rock_ui[i].text = num_of_items[i].ToString();
		}
        get_next_rock = true;
    }

    // Update is called once per frame
    void Update() {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (cur_item != null)
            cur_item.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
        if (choosen_item != -1) {

            if (Input.GetMouseButtonDown(0)) {
                print(CheckDropLocation.canDrop);
                if (num_of_items[choosen_item] > 0 && CheckDropLocation.canDrop) {
                    get_next_rock = false;
                    StartCoroutine(drop_rock(mouse_pos.x, mouse_pos.y, cur_item.gameObject));
                    num_of_items[choosen_item]--;
                    num_rock_ui[choosen_item].text = num_of_items[choosen_item].ToString();
                    cur_item = null;
                }
                else
                {
                    Destroy(cur_item);
                    cur_item = null; get_next_rock = true; choosen_item = -1;
                }
            }
        
            //JUST FOR TESTING CHANGE THIS TO ALLOW BUTTONS TO CHANGE ROCK
            if (cur_item == null && num_of_items[choosen_item] != 0 && get_next_rock) {
                cur_item = Instantiate(list_of_items[choosen_item]);
                get_next_rock = false;
            }
        }
    }


void create_ripple(float mouseX, float mouseY, Rock_Attributes cur_rock)
    {
        GameObject ripple = Instantiate(ripple_prefab);
        Ripple_Physics rp = ripple.GetComponent<Ripple_Physics>();
        rp.force = cur_rock.force;
        rp.increase_speed = cur_rock.ripple_speed;
        rp.decrease_speed = cur_rock.force_decrease;
        rp.initialized = true;
        ripple.transform.position = new Vector3(mouseX, mouseY, 0);
        
        
    }

IEnumerator drop_rock(float mouseX, float mouseY, GameObject rock)
    {
        SpriteRenderer rock_sprite = rock.GetComponent<SpriteRenderer>();
        rock_sprite.color = new Color(rock_sprite.color.r, rock_sprite.color.g, rock_sprite.color.b, 255);
        while(rock.transform.localScale.x > 0.25f)
        {
            rock.transform.localScale -= new Vector3(0.03f, 0.03f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        create_ripple(mouseX, mouseY, rock.GetComponent<Rock_Attributes>());
        rock_sound.Play();        
        Destroy(rock);
        get_next_rock = true;   
    }
	public void change_rock(int rock)
	{
		if (cur_item != null)
			Destroy (cur_item);
		cur_item = null;
		get_next_rock = true;
		choosen_item = rock;
	}
}
