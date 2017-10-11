using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxAngle;
	public float moveSpeed;
	public Component marble;
	public MeshCollider ground;

	private Rigidbody body;
	private bool gameOver;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
		gameOver = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameOver) {
			return;
		}

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical") * -1;

		Vector3 rotation = new Vector3 (moveVertical, 0.0f, moveHorizontal);

		/*if (!Input.anyKeyDown) {
			body.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		}*/

		body.transform.Rotate (rotation * moveSpeed);

		CheckOver ();
	}

	// Check if the marble has fallen below the game floor
	void CheckOver () {
		float lowest = Mathf.Infinity;
		if (marble.transform.position.y < ground.bounds.min.y) {
			print ("Fallen from world!");
			FreezeAll ();
		}
	}

	// Freeze all motion and input movements
	void FreezeAll() {
		gameOver = true;
		body.constraints = RigidbodyConstraints.FreezeAll;
		Rigidbody rigidMarble = marble.GetComponent<Rigidbody>();
		rigidMarble.constraints = RigidbodyConstraints.FreezeAll;
		Application.Quit ();
	}
}
