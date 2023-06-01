using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickup : MonoBehaviour
{
	[SerializeField] GameObject prefab;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			GameObject go = Instantiate(prefab, collision.gameObject.transform);
			go.GetComponent<Rocket>().owner = collision.gameObject.GetComponent<Rigidbody>();
			Destroy(this);
		}
	}
}
