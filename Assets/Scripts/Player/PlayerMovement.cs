using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	public float walkSpeed, runSpeed, rotateSpeed, jumpForce, walkAnimationSpeed, runAnimatonSpeed;

	public Animator animator;
	public new Rigidbody rigidbody;

	Vector3 offset;

	public float distToGround;

	public bool isGrounded;

	public Vector3 translation;

	[SerializeField] List<GameObject> grabable;
	[SerializeField] GameObject pos;
	GameObject holding = null;

	// Start is called before the first frame update
	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();

		distToGround = GetComponent<Collider>().bounds.extents.y;
	}

	// Update is called once per frame
	void Update()
	{
		isGrounded = Grounded();

		//Allow the player to move left and right
		float horizontalMove = Input.GetAxisRaw("Horizontal");
		//Allow the player to move forward and back
		float vertical = Input.GetAxisRaw("Vertical");

		float speed = walkSpeed;
		float animSpeed = walkAnimationSpeed;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			vertical *= 2f;
			speed = runSpeed;
			animSpeed = runAnimatonSpeed;
		}

		// movement
		translation = transform.forward * (vertical * Time.deltaTime);
		translation += transform.right * (horizontalMove * Time.deltaTime);
		translation *= speed;
		translation += transform.position;

		//jump
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

		float horizontal = Input.GetAxis("Mouse X") * Time.deltaTime;
		Quaternion rotation = transform.rotation * Quaternion.Euler(0, horizontal * rotateSpeed, 0);

		animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
		animator.SetFloat("Horizontal", horizontalMove, 0.1f, Time.deltaTime);

		animator.SetFloat("WalkSpeed", animSpeed);

		rigidbody.MoveRotation(rotation);

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (grabable == null)
			{

			}
			else
			{
				if (holding != null) holding = null;
				else
				{
					foreach (GameObject go in grabable)
					{
						if (holding == null) holding = go;
						else
						{
							if (Vector3.Distance(go.transform.position, transform.position) < Vector3.Distance(holding.transform.position, transform.position))
							{
								holding = go;
							}
						}
					}
				}
						
				
			}
		}
		if (holding != null)
		{
			holding.gameObject.transform.position = pos.transform.position;
		}


	}

	private void FixedUpdate()
	{
		rigidbody.MovePosition(translation);
	}

	bool Grounded()
	{
		LayerMask mask = LayerMask.GetMask("Ground");
		return Physics.Raycast(transform.position, -Vector3.up, 0.1f, mask);
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Grabable") grabable.Add(other.gameObject);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Grabable") grabable.Remove(other.gameObject);
	}
}
