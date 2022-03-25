using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : InteractableObject, IInteractable
{
    private bool pinch_started = false;
    private float initial_distance;
    private float actual_distance;
    private float actual_angle;

    private Vector3 initial_scale;
    private Quaternion initial_angle;

    private Vector3 initial_vector;
    private Vector3 actual_vector;

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
        Debug.DrawRay(our_ray.origin, Vector3.forward * 50, Color.red);
        Debug.DrawRay(second_ray.origin, Vector3.forward * 50, Color.green);

        print("Huevo");
        if (pinch_started)
        {

            actual_vector = (our_ray.origin - second_ray.origin);
            actual_angle = Vector3.Angle(actual_vector, initial_vector);
            print(actual_angle);
            transform.localRotation = initial_angle * Quaternion.AngleAxis((-actual_angle), Camera.main.transform.forward);


            actual_distance = Vector3.Distance(our_ray.origin, second_ray.origin);
            transform.localScale = initial_scale * (actual_distance / initial_distance);

        }
        else
        {
            initial_vector = our_ray.origin - second_ray.origin;
            initial_angle = transform.rotation;

            initial_distance = Vector3.Distance(our_ray.origin, second_ray.origin);
            initial_scale = transform.lossyScale;
            initial_angle = transform.rotation;
            pinch_started = true;
        }
    }

    public void pinch_ended()
    {
        pinch_started = false;
    }
}
