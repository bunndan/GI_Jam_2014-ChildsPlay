using UnityEngine;
using System.Collections;

public class Enemy_Script : MonoBehaviour {
	public Transform target;
	public float moveSpeed;
	public float rotationSpeed;
	PlatformerCharacter2D player;
	private Transform myTransform;
	
	// Use this for initialization
	void Awake() {
		myTransform = this.transform;
	}


		// Use this for initialization
	void Start () {

		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go.transform;
	}
	// Update is called once per frame
	void Update () {    
		Vector3 dir = target.position - myTransform.position;
		dir.z = 0.0f; // Only needed if objects don't share 'z' value
		if (dir != Vector3.zero) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, 
			                                         Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}
		float step = moveSpeed * Time.deltaTime;
		myTransform.position = Vector3.MoveTowards(myTransform.position, target.position, step);
		//Move Towards Target
		//myTransform.position += myTransform.position * moveSpeed * Time.deltaTime;
		
	}
	

	
	private int currentHealth = 50;
	private float knockback = 0.5f; 
	



	void OnGUI()
	{
		//display score in the top left corner of the screen.
		GUI.Label( new Rect(600,0,Screen.width, Screen.height), string.Format("Enemy's Health: {0}", currentHealth));
	}

	void OnCollisionEnter2D( Collision2D collision)
	{
				if (collision.gameObject.tag == "Player") {
						currentHealth -= 10;
			rigidbody2D.AddForce(new Vector2(0f, knockback));
						//this.transform.position.z -= 10; 
						
				}
				if (currentHealth == 0) {

			Destroy (this.gameObject);
				}
			
				}
		

	// Update is called once per frame

}
