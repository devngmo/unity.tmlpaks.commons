using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.prototypes.rpg.unit
{
    public class ChasingBehaviour : MonoBehaviour
    {
        public MovableUnit host;
        public Transform target;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (target == null)
                return;

            Vector3 d = target.position - transform.position;
            float moved = host.moveSpeed * Time.deltaTime;
            float distanceRemain = d.magnitude;
            if (moved > distanceRemain - 0.01f)
                moved = distanceRemain - 0.01f;
            transform.position += d.normalized * moved;
        }
    }
}