using UnityEngine;
using System.Collections;

public class StoreVector3
{
	public Vector3 vector;
    public StoreVector3(Vector3 source)
    {
        vector = Vector3.zero + source;
    }
}

