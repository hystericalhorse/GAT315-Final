using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] bool hasBoom = false;
    [SerializeField] float radius;
    [SerializeField] float power;
    [SerializeField] Collider[] obj;
    [SerializeField] List<GameObject> objs;

	// Start is called before the first frame update
	void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "Grabable")
        {
            objs.Add(other.gameObject);
        }
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Floor")
        {
            Boom();
		}
	}

    private void Boom()
    {
        foreach (var boomers in objs)
        {
			if (boomers.gameObject.TryGetComponent(out Rigidbody obrb))
			{
				Vector3 dir = transform.position - obrb.transform.position;
                dir = Vector3.Normalize(dir);
                //Debug.Log(boomers.gameObject.name);
                obrb.AddForce(-dir * power, ForceMode.Impulse);
				//obrb.AddExplosionForce(power, transform.position, radius);
			}
		}
        Destroy(gameObject);
    }
}
