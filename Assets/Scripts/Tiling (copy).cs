/*using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

	public int offsetX = 2; // the offset so that we don't get any weird errors

	// these are used for checking if we need to instantiate stuff
	public bool hasARightBuddy = false;
	public bool hasALeftBuddy  = false;

	public bool reverseScale   = false; // used if the objecct is not tilable
	public Transform parents;

	private float spriteWidth = 0f; // the width (length) of our element
	private Camera cam;
	private Transform myTransform;

	// all of the referencing between scripts
	void Awake () {
		cam = Camera.main;
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer> ();
		spriteWidth = sRenderer.sprite.bounds.size.x; // gets width of the element no matter the size
	}
	
	// Update is called once per frame
	void Update () {
		if (hasALeftBuddy == false || hasARightBuddy == false) {
			// calculate the camera extend (half the width) of what the camera can see in world coordinates (length from center of the camera to point B)
			float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

			// calculate the x position where the camera can see the edge of the sprite (element)
			float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
			float edgeVisiblePositionLeft  = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

			// Checking if we can see the edge of the element and then calling MakeNewBuddy if we can
			if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX && hasARightBuddy == false) { 
				MakeNewBuddy (1);
				hasARightBuddy = true;
			} else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false) {
				MakeNewBuddy (-1);
				hasALeftBuddy = true;
			}
		}
	}

	// A function that creates a buddy on the side required
	void MakeNewBuddy (int rightOrLeft) {
		// Calculating the new position for our new buddy
		Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
		// instantiating/representing our new buddy and storing him in a variable
		Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform; // casting variable as a Transform. Can use (Transform).

		// if not tilable, let's reverse the x size of our object to get rid of ugly seams
		if (reverseScale == true) {
			newBuddy.localScale = new Vector3 (newBuddy.localScale.x * - 1, newBuddy.localScale.y, newBuddy.localScale.z);
		}

		newBuddy.transform.parent = parents.transform;
		if (rightOrLeft > 0) {
			newBuddy.GetComponent<Tiling> ().hasALeftBuddy = true;
		} else {
			newBuddy.GetComponent<Tiling> ().hasARightBuddy = true;
		}
	}
}
*/