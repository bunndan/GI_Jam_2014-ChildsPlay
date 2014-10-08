using UnityEngine;
using System.Collections;

public class IntroductionDialog : MonoBehaviour {

	//introduction dialog already triggered?
	public bool intro_dialog_triggered;

	// Use this for initialization
	void Start () {
		intro_dialog_triggered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//player passed over trigger??
	void OnTriggerEnter2D(Collider2D col){

		GameObject go = GameObject.Find ("Bubble Text Manager");
		if (!intro_dialog_triggered && col.gameObject.name == "Player") {
			go.transform.SendMessage("DispDialog", 1, SendMessageOptions.RequireReceiver);		//request intro dialog
		}
		intro_dialog_triggered = true;
	}
	
}
