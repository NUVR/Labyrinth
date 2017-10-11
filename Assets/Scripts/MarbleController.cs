using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Finish") {
			print ("Game over");
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
			Application.Quit ();
		}
	}
}
