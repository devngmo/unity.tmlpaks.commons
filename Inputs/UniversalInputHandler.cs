using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalInputHandler : MonoBehaviour
{
    protected bool mIsMoving = true;
    public bool IsMoving { 
        get => mIsMoving;
    }

    List<UIHListener> listeners = new List<UIHListener>();
    public void register(UIHListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void unregister(UIHListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

    protected bool mIsRotating = false;
    public bool IsRotating { get => mIsRotating; }

    public virtual Vector3 GetScreenPosition()
    {
        return Input.mousePosition;
    }

    public float getHorizontalMovementValue()
    {
        return Input.GetAxis("Horizontal");
    }

    public float getVerticalMovementValue()
    {
        return Input.GetAxis("Vertical");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
