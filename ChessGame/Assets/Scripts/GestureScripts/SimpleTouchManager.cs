using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTouchManager : MonoBehaviour, ITouchController
{

    private Transform selectedObject;
    private bool objectFound = false;

    public void tap(Vector2 position)
    {
        Ray our_ray = Camera.main.ScreenPointToRay(position);
        //Debug.DrawRay(our_ray.origin, our_ray.direction * 50, Color.red);
        RaycastHit hit_info;
        if (Physics.Raycast(our_ray, out hit_info))
        {

            selectedObject = hit_info.transform;

            IInteractable interactable = selectedObject.GetComponent<IInteractable>();

            if (interactable != null)
            {

                interactable.selectToggle();
                if (interactable is CubeController)
                {
                    (interactable as CubeController).CubeStuff();

                }
                if (!(interactable as InteractableObject).isSelected)
                {
                    selectedObject = null;
                }
            }
        }
    }

    public void drag(Vector2 position)
    {
        IInteractable interactable = null;
        if (selectedObject != null && objectFound)
        {

            interactable = selectedObject.GetComponent<IInteractable>();

            Ray our_ray = Camera.main.ScreenPointToRay(position);
            //Debug.DrawRay(our_ray.origin, our_ray.direction * 50, Color.red);

            interactable.drag(our_ray);


        }
        else if (interactable != null)
        {
            print("Object not Found");
        }
    }
    public void findInteractableObject(Vector2 position)
    {
        Ray our_ray = Camera.main.ScreenPointToRay(position);

        RaycastHit hit_info;
        if (Physics.Raycast(our_ray, out hit_info))
        {
            if (hit_info.transform.GetComponent<InteractableObject>() != null)
            {
                objectFound = true;
            }
            else
            {
                objectFound = false;
            }
        }
        else
        {
            objectFound = false;
        }
    }



    public void pinch(Vector2 first_touch, Vector2 second_touch)
    {


        IInteractable interactable = null;

        if (selectedObject == null && objectFound)
        {

            interactable = selectedObject.GetComponent<IInteractable>();

            Ray first_ray = Camera.main.ScreenPointToRay(first_touch);
            Ray second_ray = Camera.main.ScreenPointToRay(second_touch);


            interactable.pinch(first_ray, second_ray);

        }
        else if (interactable != null)
        {
            print("Object not Found");
        }



    }

}
