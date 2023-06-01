using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject Player;
	int alive = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = transform.position;
    }
	private void LateUpdate()
	{
		Player.transform.position = transform.position;
		//Destroy(this);
	}

	// Update is called once per frame
	void Update()
    {
		Player.transform.position = transform.position;
		if (alive == 10) Destroy(this);
		else alive++;
		//Destroy(this);
	}
}
