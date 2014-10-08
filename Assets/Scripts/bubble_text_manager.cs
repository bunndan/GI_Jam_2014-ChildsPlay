using UnityEngine;
using System.Collections;

public class bubble_text_manager : MonoBehaviour {

	//create a singleton of this object
	private static bubble_text_manager instance = null;
	public static bubble_text_manager Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	//dialog object
	public GUI_Bubble_Text bubble_text;

	// Use this for initialization
	void Start () {
		bubble_text = new GUI_Bubble_Text ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	//displays a series of dialogs depend on which dialog transition we're in currently
	void DispDialog(int which_dialog_num){
		if (which_dialog_num == 1) {		//first dialog
			StartCoroutine (Intro1 ());
		} else if (which_dialog_num == 2) {
			StartCoroutine (GateDialog());
		}
	}

	//add a new dialog
	void GenDialog(dialog_info di){
		bubble_text.AddDialog (GameObject.Find (di.obj_name), di.dialog, di.dialog_width, di.time_duration);
	}

	//display bubbles
	void OnGUI() {
		bubble_text.UpdateDialogs ();
	}

	//dialog #1 routine
	IEnumerator Intro1(){

		//dialog #1
		dialog_info c1;
		c1.obj_name = "MC";
		c1.dialog = "The day has finally come...";
		c1.dialog_width = 200;
		c1.time_duration = 5;
		GenDialog (c1); 

		yield return new WaitForSeconds (5);

		//dialog #2
		dialog_info c2;
		c2.obj_name = "MC";
		c2.dialog = "My quest, and mine alone...";
		c2.dialog_width = 200;
		c2.time_duration = 5;
		GenDialog (c2); 

		yield return new WaitForSeconds (5);

		//dialog #3
		dialog_info c3;
		c3.obj_name = "MC";
		c3.dialog = "Press <left/right arrow> keys to move";
		c3.dialog_width = 200;
		c3.time_duration = 8;
		GenDialog (c3);  

		yield return new WaitForSeconds (9);

		//dialog #4
		dialog_info c4;
		c4.obj_name = "MC";
		c4.dialog = "I must venture forward...";
		c4.dialog_width = 200;
		c4.time_duration = 5;
		GenDialog (c4); 

		yield return new WaitForSeconds (5);

		//dialog #5
		dialog_info c5;
		c5.obj_name = "MC";
		c5.dialog = "Press <space> to jump";
		c5.dialog_width = 200;
		c5.time_duration = 8;
		GenDialog (c5);  

		yield return new WaitForSeconds (9);

		//dialog #6
		dialog_info c6;
		c6.obj_name = "MC";
		c6.dialog = "... and slay all who obstruct my path!";
		c6.dialog_width = 200;
		c6.time_duration = 5;
		GenDialog (c6); 

		yield return new WaitForSeconds (5);

		//dialog #7
		dialog_info c7;
		c7.obj_name = "MC";
		c7.dialog = "Press <shift> to attack";
		c7.dialog_width = 200;
		c7.time_duration = 8;
		GenDialog (c7); 

		yield return new WaitForSeconds (9);

		//dialog #7
		dialog_info c8;
		c8.obj_name = "MC";
		c8.dialog = "Onward!";
		c8.dialog_width = 100;
		c8.time_duration = 10;
		GenDialog (c8); 

		yield return new WaitForSeconds (1);

		}

	//dialog #1 routine
	IEnumerator GateDialog(){
		
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "Halt! Who goes there!",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("MC"),
	                       "I am the warrior/mage/savior to slay the __________",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "Ah, it is you. We, the gatekeepers, have heard your name.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);
	
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "We must warn you of the many dangers you will face once you pass through these doors.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);
	
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "The ________ is short... tall.",
	                       200,
	                       5);
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "The ________ is tall... short.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "Anyway, he holds the Almighty Hammer of Un-justice!!",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "Yeah what he said -- and it's 'Injustice'.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("MC"),
	                       "Okay, so what would I need to do?",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "Euh... make sure you have enough money, and life.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "So yu don't die.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("MC"),
	                       "... I have them. Can I go now?",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "Yes!",
	                       200,
	                       5);
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "No!",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "*whispers* he's not here yet.",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "Oh... no...",
	                       200,
	                       5);
			yield return new WaitForSeconds (5);
	
			bubble_text.AddDialog (GameObject.Find ("MC"),
	                       "...",
	                       200,
	                       5);
			yield return new WaitForSeconds (1);
	
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "...",
	                       200,
	                       6);
			yield return new WaitForSeconds (1);

			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "...",
	                       200,
	                       5);
			yield return new WaitForSeconds (4);
	
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 1"),
	                       "... Now you can go.",
	                       200,
	                       3);
			yield return new WaitForSeconds (3);
	
			bubble_text.AddDialog (GameObject.Find ("Gatekeeper 2"),
	                       "Good luck, warrior.",
	                       200,
	                       3);
			yield return new WaitForSeconds (3);
		}
}
