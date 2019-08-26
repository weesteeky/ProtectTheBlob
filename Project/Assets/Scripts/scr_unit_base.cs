using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_unit_base : MonoBehaviour
{
    private string unit_name = "snuffles";
    private float unit_speed = 1.5f;
    private bool selected = false;
    float CLICK_RANGE = 0.2f; 
    private bool moving = false;
    
    private float start_time; 
    private Vector2 target_pos;
    private Vector2 starting_pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Vector2 mouse_vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(transform.position.x >= (mouse_vec.x - CLICK_RANGE) && transform.position.x <= (mouse_vec.x + CLICK_RANGE)) {
                
                if(transform.position.y >= (mouse_vec.y - CLICK_RANGE) && transform.position.y <= (mouse_vec.y + CLICK_RANGE)) {
                    if(selected) {
                        selected = false;
                    }
                    else {
                        selected = true;
                        Debug.Log("Selected");
                    }
                }
            }
            else if(selected){
                if(!moving){
                    start_time = Time.time;
                    target_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target_pos.y = transform.position.y;
                    starting_pos = transform.position;
                    moving = true;
                    selected = false;
                }

            }
        }

        if(moving){
            float current_time = Time.time;
            float coveredDist = (current_time - start_time) * unit_speed;

            float len_journey = (target_pos.x - starting_pos.x);
            float frac_journey = coveredDist/len_journey;
            
            if(transform.position.x > target_pos.x){
                transform.position = Vector3.Lerp(starting_pos, target_pos, -frac_journey);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            } else {
                transform.position = Vector3.Lerp(starting_pos, target_pos, frac_journey);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if(target_pos.x >= (transform.position.x - CLICK_RANGE/2) && target_pos.x <= (transform.position.x + CLICK_RANGE/2)){
                Debug.Log("Reached");
                moving = false;
            }
        }

        if(selected){
            // draw rect
        }
    }
}
