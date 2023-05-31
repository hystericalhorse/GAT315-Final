using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] bool singleUse = false;
    [SerializeField] GameObject target;
	[SerializeField] Animator animator;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Button Enter");
		animator.SetBool("Pressed", true);
		if (target != null)
        {
			
            // the function that is needed
            //target.GetComponent
        }
	}


	private void OnTriggerExit(Collider other)
	{
		Debug.Log("Button Exit");
		animator.SetBool("Pressed", false);
		if (!singleUse)
		{
			// deactivate the obj
		}
	}

}
