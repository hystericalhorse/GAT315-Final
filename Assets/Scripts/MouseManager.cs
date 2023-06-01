using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
	bool cursorActive = false;

	private void Start()
	{
		
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			cursorActive = !cursorActive;

			Cursor.lockState = (cursorActive) ? CursorLockMode.None : CursorLockMode.Locked;
		}
	}

	private void LateUpdate()
	{
        
    }
}

