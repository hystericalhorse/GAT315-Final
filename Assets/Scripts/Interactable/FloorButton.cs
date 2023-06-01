using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] bool singleUse = false;
    [SerializeField] GameObject target;
	[SerializeField] Animator animator;

	List<GameObject> pressers = new List<GameObject>();

	private void OnTriggerEnter(Collider other)
	{
		if (pressers.Count == 0) animator.SetBool("Pressed", true);
		if (target != null)
        {
			if (pressers.Count == 0)
			{
				Animator targetAni = target.GetComponent<Animator>();
				targetAni.SetBool("IsOpen", true);
			}
				
            // the function that is needed
            //target.GetComponent
        }
		pressers.Add(other.gameObject);
	}


	private void OnTriggerExit(Collider other)
	{
		pressers.Remove(other.gameObject);
		if (pressers.Count == 0) animator.SetBool("Pressed", false);
		if (!singleUse)
		{
			// remove this to set the animator at start
			if (pressers.Count == 0)
			{
				Animator targetAni = target.GetComponent<Animator>();
				targetAni.SetBool("IsOpen", false);
			}
				
			// deactivate the obj
		}
	}

}
