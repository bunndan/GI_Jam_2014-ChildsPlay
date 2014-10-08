using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name.Contains ("enemy") || coll.gameObject.name.Contains ("boss") || coll.gameObject.name.Contains ("Boss") ){
			
			GameObject.Destroy(coll.gameObject);
		}
	}
}
