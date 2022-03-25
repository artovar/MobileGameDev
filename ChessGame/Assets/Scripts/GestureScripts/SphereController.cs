using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : InteractableObject, IInteractable
{
    private GameObject plane;

    public void selectToggle()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            myRenderer.material.color = Color.blue;
        }
        else
        {
            myRenderer.material.color = Color.white;
        }
    }

    public void drag(Ray our_ray)
    {
        Ray plane_ray = Camera.main.ScreenPointToRay(our_ray.direction);

        Debug.DrawRay(plane_ray.origin, plane_ray.direction * 80, Color.green);
        //Debug.DrawRay(our_ray.origin, our_ray.direction * 50, Color.red);
        RaycastHit hit_info;

        if (drag_started)
        {
            if (Physics.Raycast(our_ray, out hit_info, Mathf.Infinity, LayerMask.GetMask("Plane")))
            {
                if (hit_info.transform.CompareTag("Plano"))
                {
                    transform.position = our_ray.GetPoint(hit_info.distance);
                }
            }
            else
            {
                transform.position = our_ray.GetPoint(distance);
            }

        }
        else
        {
            distance = Vector3.Distance(our_ray.origin, transform.position);
            drag_started = true;
        }






    }
    public void pinch(Ray our_ray, Ray second_ray) { }
    public void pinch_ended() { }
}
