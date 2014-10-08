using UnityEngine;
using System.Collections;

public class PanCam : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Vector3 Velocity = new Vector3(0, -2 ,0);
		rigidbody2D.velocity = (Vector3) (Velocity);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
