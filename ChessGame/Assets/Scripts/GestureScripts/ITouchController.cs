using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchController
{

    public void tap(Vector2 position);

    public void drag(Vector2 position);

    public void pinch(Vector2 first_touch, Vector2 second_touch);

    public void findInteractableObject(Vector2 position);
}