using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Rigidbody player;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float rotationSpeed;

	private Vector3 rotation;

	void Start () {
		player = GetComponent<Rigidbody> ();
	}

	void Update () {
		rotation = new Vector3 (Input.GetAxis("Vertical") * rotationSpeed, Input.GetAxis("Horizontal") * rotationSpeed, -Input.GetAxis("Look") * rotationSpeed);
		player.AddRelativeTorque (rotation);
		player.AddRelativeForce (0, 0, Input.GetAxis ("Swim") * speed);
	
	}

}
