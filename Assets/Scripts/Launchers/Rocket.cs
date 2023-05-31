using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Desired behaviors: pickup launcher, timer starts, it goes.

    [SerializeField] Launcher launcher;
    [SerializeField] float live_time;

    public Rigidbody owner;

    // Start is called before the first frame update
    void Start()
    {
        live_time = launcher.Timer;
    }

    // Update is called once per frame
    void Update()
    {
		this.transform.position = owner.transform.position;
		if (live_time > 0) live_time -= Time.deltaTime;

        if (live_time <= 0)
        {
            owner.AddForce(Vector3.up * launcher.Power, ForceMode.Impulse);
        }
    }

	private void LateUpdate()
	{
		if (live_time <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
