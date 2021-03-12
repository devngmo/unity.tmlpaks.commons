using UnityEngine;
using System.Collections;

public class StoreTransform
{
	public Vector3 up;
	public Vector3 forward;
	public Vector3 right;

	public Vector3 position;
	public Quaternion rotation;
	public Vector3 localScale;

	public static StoreTransform saveFrom(Transform source)
	{
		StoreTransform st = new StoreTransform();
		st.position = source.localPosition;
		st.rotation = source.localRotation;
		st.localScale = source.localScale;

		st.up = source.up;
		st.forward = source.forward;
		st.right = source.right;
		return st;
	}

	public void loadTo(Transform target)
	{
		target.localPosition = position;
		target.localRotation = rotation;
		target.localScale = localScale;
	}
}

