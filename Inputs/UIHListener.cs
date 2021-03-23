using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UIHListener
{
    void OnUIHEvent(UniversalInputHandler sender, string msg);
}
