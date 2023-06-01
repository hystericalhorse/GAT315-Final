using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravWell : MonoBehaviour
{
	[SerializeField] float multiplyer = 0;

	List<GameObject> obj = new List<GameObject>();

	private void FixedUpdate()
	{
		foreach (GameObject obj in obj)
		{
			if (obj.TryGetComponent(out Rigidbody rb))
			{
				float y = (obj.transform.position.y - transform.position.y) + 0.1f; 

				rb.AddForce((Physics.gravity * multiplyer) * -(1/y), ForceMode.Impulse);
			}
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
