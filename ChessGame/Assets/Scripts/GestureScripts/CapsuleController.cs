using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : InteractableObject, IInteractable
{

    private GameObject plane;
    // Start is called before the first frame update

    private void Awake()
    {

        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);

        plane.GetComponent<MeshRenderer>().enabled = false;
        plane.GetComponent<Collider>().enabled = false;
        plane.tag = "Plano";
        plane.layer = 4;

        plane.transform.position = transform.position;
        plane.transform.localScale = transform.localScale * 10;
        plane.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

    }


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

        plane.GetComponent<Collider>().enabled = isSelected;
    }


    public void drag(Ray our_ray)
    {
        RaycastHit hit_info;

        if (Physics.Raycast(our_ray, out hit_info))
        {
            if (hit_info.transform.CompareTag("Plano"))
            {
                transform.position = our_ray.GetPoint(hit_info.distance);
            }

        }
    }


    public void pinch(Ray our_ray, Ray second_ray) { }

}
