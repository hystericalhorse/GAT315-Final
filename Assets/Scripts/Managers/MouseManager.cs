using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
	bool cursorActive = false;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
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

