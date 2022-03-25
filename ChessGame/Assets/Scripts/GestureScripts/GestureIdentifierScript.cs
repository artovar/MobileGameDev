using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureIdentifierScript : MonoBehaviour
{


    private float tap_timer;
    private bool has_moved;
    private bool second_has_moved = false;
    private float MAX_ALLOWED_TAP_TIME = 0.7f;

    SimpleTouchManager[] managers;


    // Start is called before the first frame update
    void Start()
    {
        //var ss = FindObjectOfType<ITouchController>();
        managers = FindObjectsOfType<SimpleTouchManager>();
    }

    // Update is called once per frame
    void Update()
    {

        tap_timer += Time.deltaTime;
        Touch[] all_touches = Input.touches;
        if (Input.touchCount >= 1)
        {
            Touch first_touch = all_touches[0];

            switch (first_touch.phase)
            {
                case TouchPhase.Began:
                    tap_timer = 0;
                    has_moved = false;
                    foreach (ITouchController manager in managers)
                    {
                        manager.findInteractableObject(first_touch.position);
                    }
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Moved:
                    has_moved = true;
                    if (!second_has_moved)
                    {
                        foreach (ITouchController manager in managers)
                        {
                            print("Im draggin");
                            manager.drag(first_touch.position);
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (tap_timer < MAX_ALLOWED_TAP_TIME && !has_moved)
                    {
                        foreach (ITouchController manager in managers)
                        {
                            manager.tap(first_touch.position);
                        }
                    }
                    break;

            }

        }
        if (Input.touchCount >= 2)
        {
            Touch first_touch = all_touches[0];
            Touch second_touch = all_touches[1];

            switch (second_touch.phase)
            {

                case TouchPhase.Began:
                    second_has_moved = true;
                    foreach (ITouchController manager in managers)
                    {
                        manager.findInteractableObject(second_touch.position);
                    }
                    break;

                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    second_has_moved = true;
                    foreach (ITouchController manager in managers)
                    {
                        print("Im pinchin");
                        manager.pinch(first_touch.position, second_touch.position);
                    }

                    break;
                case TouchPhase.Ended:
                    second_has_moved = false;
                    foreach (ITouchController manager in managers)
                    {
                        print("Im pinchin");
                        manager.pinch_ended();
                    }

                    break;

            }
        }
    }


}
