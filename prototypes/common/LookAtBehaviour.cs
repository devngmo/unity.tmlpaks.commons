using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.prototypes.common
{
    public class LookAtBehaviour : MonoBehaviour
    {
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(transform.up, transform.position);
            float distance;
            plane.Raycast(ray, out distance);
            Vector3 target=  ray.GetPoint(distance);
            transform.LookAt(target);
        }
    }
}