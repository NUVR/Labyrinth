using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxAngle;
	public float moveSpeed;
	public Component marble;
	public MeshCollider ground;

	private Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical") * -1;

		Vector3 rotation = new Vector3 (moveVertical, 0.0f, moveHorizontal);

		/*if (!Input.anyKeyDown) {
			body.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		}*/

		body.transform.Rotate (rotation * moveSpeed);

		CheckOver ();
	}

	void CheckOver () {
		float lowest = Mathf.Infinity;
		if (marble.transform.position.y < ground.bounds.min.y) {
			print ("DONE: " + marble.transform.position.y + ", " + ground.bounds.min.y);
		}
	}
}
