using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : InteractableObject, IInteractable
{
    void Update()
    {

    }
    internal void MoveUp()
    {
        transform.position += Vector3.up;
    }
    public void selectToggle()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            myRenderer.material.color = Color.red;
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

    internal void CubeStuff()
    {
        print("Im a madafucking cube");
    }
    public void pinch(Ray our_ray, Ray second_ray) { }
}
