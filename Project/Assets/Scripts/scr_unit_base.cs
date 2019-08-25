using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_unit_base : MonoBehaviour
{
    private string unit_name = "snuffles";
    private float unit_speed = 3.0f;
    private bool selected = false;
    float CLICK_RANGE = 0.2f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 mouse_vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(transform.position.x >= (mouse_vec.x - CLICK_RANGE) && transform.position.x <= (mouse_vec.x + CLICK_RANGE))
            {
                if(transform.position.y >= (mouse_vec.y - CLICK_RANGE) && transform.position.y <= (mouse_vec.y + CLICK_RANGE))
                {
                    if(selected) selected = false;
                    else selected = true;

                    Debug.Log("selected: " + selected);
                }
            }
        }
    }
}
