using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons.animations
{
    public class SelfRotation : MonoBehaviour
    {
        public float speed = 1;
        public Vector3 axis = Vector3.up;
        
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float angle = speed * Time.deltaTime;
            transform.Rotate(axis, angle);
        }
    }
}