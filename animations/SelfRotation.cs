using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons.animations
{
    [ExecuteInEditMode]
    public class SelfRotation : MonoBehaviour
    {
        public float speed = 1;
        public Vector3 axis = Vector3.up;
        public bool runInEditMode = false;
        
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!runInEditMode)
            {
                if (Application.isEditor) return;
            }
            float angle = speed * Time.deltaTime;
            transform.Rotate(axis, angle);
        }
    }
}