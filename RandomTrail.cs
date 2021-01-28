using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrail : MonoBehaviour
{
    TrailRenderer _trailRenderer;
    TrailRenderer Trail { get {
            if (_trailRenderer == null)
                _trailRenderer = GetComponent<TrailRenderer>();
            return _trailRenderer;
        } 
    }

    public float MinTime = 0;
    public float MaxTime = 2;

    private float timestamp = 0;
    private float trailDuration = 0;

    void Start()
    {
        trailDuration = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        if (Time.time > timestamp + trailDuration)
        {
            trailDuration = Random.Range(MinTime, MaxTime);
            timestamp = Time.time;
            Trail.emitting = !Trail.emitting;
        }
    }
}
