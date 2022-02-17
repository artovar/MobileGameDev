using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    public void selectToggle();

    public void drag(Ray our_ray);

    public void pinch(Ray our_ray, Ray second_ray);

}
