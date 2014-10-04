using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;

	// Update is called once per frame
	void Update () {
		// difference between the position of our mouse in 3D space and the position of our character.
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		// Normalizing the 3D vector. Making the sum of the values equal to 1 (x + y + z = 1). Keeping proportions of the values but just making them smaller.
		difference.Normalize ();

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; // find the rotation in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
	}
}
