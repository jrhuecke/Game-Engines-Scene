using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float radius;
    public float speed;
    public float height;

    private Vector3 movement;
    private float angle;

    public Transform lookTarget;

    private Camera cam;
    int wall1, wall2, wall3, wall4, alwaysShow;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        wall1 = LayerMask.NameToLayer("Wall1");
        wall2 = LayerMask.NameToLayer("Wall2");
        wall3 = LayerMask.NameToLayer("Wall3");
        wall4 = LayerMask.NameToLayer("Wall4");
        alwaysShow = LayerMask.NameToLayer("Default");
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the camera in a circle while keeping it looking at center of room
        movement.Set(Mathf.Cos(angle) * radius, height, Mathf.Sin(angle) * radius);
        transform.position = lookTarget.position + movement;
        angle += Time.deltaTime * speed;
        transform.LookAt(lookTarget);

        //Edits what layers the camera can see based on what quarter of the circle it is in
        if (transform.position.x > 0 && transform.position.z > 0)
        {
            cam.cullingMask = (1 << wall1) | (1 << wall2) | (1 << alwaysShow);
        }
        else if (transform.position.x > 0 && transform.position.z < 0)
        {
            cam.cullingMask = (1 << wall1) | (1 << wall4) | (1 << alwaysShow);
        }
        else if (transform.position.x < 0 && transform.position.z < 0)
        {
            cam.cullingMask = (1 << wall3) | (1 << wall4) | (1 << alwaysShow);
        }
        else if (transform.position.x < 0 && transform.position.z > 0)
        {
            cam.cullingMask = (1 << wall2) | (1 << wall3) | (1 << alwaysShow);
        }
    }
}
