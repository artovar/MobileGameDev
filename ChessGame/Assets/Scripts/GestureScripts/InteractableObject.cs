using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool isSelected = false;
    public Renderer myRenderer;

    public bool drag_started = false;
    public float distance;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    void Update()
    {

    }
}
