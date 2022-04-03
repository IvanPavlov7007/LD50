using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLight : MonoBehaviour
{
    public float offset;

    // Update is called once per frame
    void Update()
    {
        Plane plane = new Plane(Vector3.forward, Vector3.up);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.GetPoint(distance + offset);
        }
    }
}
