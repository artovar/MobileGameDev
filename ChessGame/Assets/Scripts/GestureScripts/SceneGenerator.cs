using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneGenerator : MonoBehaviour
{

    GameObject plane;
    GameObject cube;
    GameObject sphere;
    GameObject capsule;

    GameObject cyllinder;

    GameObject gestureIndentifier;
    GameObject touchManager;


    // Start is called before the first frame update
    void Start()
    {
        //Adding Eventsystem.
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }



        gestureIndentifier = new GameObject("GestureIdentifier");
        gestureIndentifier.AddComponent<GestureIdentifierScript>();

        touchManager = new GameObject("TouchManager");
        touchManager.AddComponent<SimpleTouchManager>();



        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.layer = LayerMask.NameToLayer("Plane");
        plane.tag = "Plano";
        plane.transform.position = new Vector3(0f, -3f, -4f);
        plane.transform.localScale = new Vector3(1f, 1f, 2f);





        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0f, 1.5f, 0f);
        cube.AddComponent<CubeController>();

        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0f, 0f, 0f);
        sphere.AddComponent<SphereController>();

        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.transform.position = new Vector3(2f, 1f, 0f);
        capsule.AddComponent<CapsuleController>();

        cyllinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyllinder.transform.position = new Vector3(-1.15f, 3.5f, 0f);

        cyllinder.AddComponent<CylinderController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
