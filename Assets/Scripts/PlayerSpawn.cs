using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		Player.transform.position = transform.position;
        Destroy(this);
	}
}
