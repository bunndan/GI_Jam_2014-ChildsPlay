using UnityEngine;
using System.Collections;

public class Circle2d : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		// On Click, load the first level.
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
