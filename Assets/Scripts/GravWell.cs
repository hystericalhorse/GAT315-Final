using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravWell : MonoBehaviour
{
	List<GameObject> obj = new List<GameObject>();

	private void FixedUpdate()
	{
		foreach (GameObject obj in obj)
		{
			if (obj.TryGetComponent(out Rigidbody rb)) rb.AddForce((-Physics.gravity * rb.mass) * 1.2f);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		obj.Add(other.gameObject);
		
	}
	private void OnTriggerExit(Collider other)
	{
		obj.Remove(other.gameObject);
	}
}
