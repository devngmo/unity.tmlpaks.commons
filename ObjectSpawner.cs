using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tmlpaks.commons
{
    public class ObjectSpawner : MonoBehaviour
    {
        public Transform objectTemplate;
        public enum TimeModes { FixedInterval, RandomInRange }
        public TimeModes timeMode = TimeModes.FixedInterval;
        public float fixedInterval = 1;

        [Header("Time Range in Seconds")]
        public float minInterval = 1;
        public float maxInterval = 2;

        public enum SpawnPolicies { CreateInstance, SendMessage, SendMessageUpwards }
        public SpawnPolicies SpawnPolicy = SpawnPolicies.CreateInstance;

        public bool SpawnOnStart = true;

        void Start()
        {
            if (SpawnOnStart) Spawn();
        }

        float timePassed = 0;
        void Update()
        {
            timePassed += Time.deltaTime;

            if (timeMode == TimeModes.FixedInterval)
            {
                if (timePassed >= fixedInterval)
                {
                    timePassed -= fixedInterval;
                    Spawn();
                }
            }
            else
            {
                float currentInteval = UnityEngine.Random.Range(minInterval, maxInterval);
                if (timePassed >= currentInteval)
                {
                    timePassed -= currentInteval;
                    Spawn();
                }
            }
        }

        private void Spawn()
        {
            if (SpawnPolicy == SpawnPolicies.CreateInstance)
            {
                var newObj = GameObject.Instantiate(objectTemplate);
                newObj.transform.position = transform.position;
            }
            else if (SpawnPolicy == SpawnPolicies.SendMessage)
            {
                SendMessage("SpawnObject", objectTemplate);
            }
            else if (SpawnPolicy == SpawnPolicies.SendMessageUpwards)
            {
                SendMessageUpwards("SpawnObject", objectTemplate);
            }
        }
    }
}