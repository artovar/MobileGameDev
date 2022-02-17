using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : InteractableObject, IInteractable
{
    private bool pinch_started = false;
    private float initial_distance;
    private float actual_distance;

    private Vector3 initial_scale;

    public void selectToggle()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            myRenderer.material.color = Color.yellow;
        }
        else
        {
            myRenderer.material.color = Color.white;
        }
    }

    public void drag(Ray our_ray)
    {
        if (drag_started)
        {
            transform.position = our_ray.GetPoint(distance);
        }
        else
        {
            distance = Vector3.Distance(our_ray.origin, transform.position);
            drag_started = true;
        }
    }



    public void pinch(Ray our_ray, Ray second_ray)
    {
        Debug.DrawRay(our_ray.origin, Vector3.forward, Color.red);
        Debug.DrawRay(second_ray.origin, Vector3.forward, Color.green);

        
        if (pinch_started)
        {
            actual_distance = Vector3.Distance(our_ray.origin, second_ray.origin);

            transform.localScale = initial_scale * (actual_distance / initial_distance);
            print(transform.localScale);
        }
        else
        {
            initial_distance = Vector3.Distance(our_ray.origin, second_ray.origin);
            initial_scale = transform.localScale;
            pinch_started = false;
        }
    }


}
