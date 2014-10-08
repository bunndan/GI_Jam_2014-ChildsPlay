using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//structure to hold one dialog info
public struct dialog_info{
	public string obj_name;
	public string dialog;
	public int dialog_width;
	public float time_duration;
}

//bubble text class
public class GUI_Bubble_Text
{
	//main bounding box
	public List<string> obj_name;
	public List<string> dialog;
	public List<int> dialog_width;
	public List<float> start_time, time_duration;
	public int num_dialogs;						//number of dialogs currently

	//constructor
	public GUI_Bubble_Text () {
		//clear out all of our lists
		obj_name = new List<string> ();
		dialog = new List<string> ();
		dialog_width = new List<int> ();
		start_time = new List<float> ();
		time_duration = new List<float> ();
		num_dialogs = 0;
	}

	//determine bounding box given game object and assign it to our class public var
	public Rect FindBounds(int dindex){

		Rect bbox;
		GameObject gobj = GameObject.Find (obj_name [dindex]);

		//find the two extreme corners of the box bounding our talking object
		Vector3 min_pos, max_pos;
		min_pos = Camera.main.WorldToScreenPoint (new Vector3 (gobj.renderer.bounds.min.x,
		                                                       gobj.renderer.bounds.min.y, 
		                                                       gobj.renderer.bounds.min.z));
		max_pos = Camera.main.WorldToScreenPoint (new Vector3 (gobj.renderer.bounds.max.x,
		                                                       gobj.renderer.bounds.max.y, 
		                                                       gobj.renderer.bounds.max.z));
		bbox = new  Rect(min_pos.x, Screen.height - max_pos.y, max_pos.x-min_pos.x, max_pos.y-min_pos.y);

		return bbox;	//return our bounding box
	}

	//add new dialog
	public void AddDialog(GameObject talking_obj, string dialogTxt, int dialogWidth, float dialogDuration) {

		if (talking_obj != null) {
			//setup our dialog info
			obj_name.Add (talking_obj.name);
			dialog.Add (dialogTxt);
			dialog_width.Add (dialogWidth);
			time_duration.Add (dialogDuration);
			start_time.Add (Time.time);
			num_dialogs = num_dialogs + 1;
		}
	}

	//remove old dialog
	public void RemoveDialog(int dindex) {
		obj_name.RemoveAt (dindex);
		dialog.RemoveAt (dindex);
		dialog_width.RemoveAt (dindex);
		time_duration.RemoveAt (dindex);
		start_time.RemoveAt (dindex);
		num_dialogs = num_dialogs - 1;
	}

	//gui render a bubble text of dialog index dindex
	public void DrawBubbleText(int dindex){
		//order of priority, top right corner, then top left corner, then bot right corner, then bot left corner

		//just some default bubble style
		GUIStyle style = new GUIStyle();
		style.fontSize = 20;
		style.normal.textColor = Color.white;
		style.wordWrap = true;

		//determine bubble specs
		int bubble_padding = 10;					//10 pixel padding
		int bubble_width = dialog_width[dindex];
		int bubble_height = (int)style.CalcHeight(new GUIContent(dialog[dindex]), bubble_width);

		//object grab bounding box
		Rect bbox = FindBounds(dindex);
		bool fitright = false;		//able to fit right?
		bool fittop = false;		//able to fit top?
		bool fitleft = false;
		bool fitbot = false;

		//able to fit to the top of object?
		if (bbox.min.y - 2 * bubble_padding - bubble_height > 0) {
			fittop = true;
		}
		//able to fit to the right of object?
		if (bbox.max.x + 2 * bubble_padding + bubble_width < Screen.width) {
			fitright = true;
		}
		//able to fit to the top of object?
		if (bbox.max.y + 2 * bubble_padding + bubble_height < Screen.height) {
			fitbot = true;
		}
		//able to fit to the right of object?
		if (bbox.min.x - 2 * bubble_padding - bubble_width > 0) {
			fitleft = true;
		}
		
		//try the order of priority (assuming our text fits)
		if (fitright && fittop) {		//top right
			GUI.Box (new Rect(bbox.max.x, 
			                  bbox.min.y - 2*bubble_padding - bubble_height,
			                  bubble_width + 2*bubble_padding,
			                  bubble_height + 2*bubble_padding), "");				//draw bounding box
			GUI.Label (new Rect(bbox.max.x + bubble_padding,
			                    bbox.min.y - bubble_padding - bubble_height,
			                    bubble_width,
			                    bubble_height), dialog[dindex], style);				//render dialog
		}
		else if (fitleft && fittop) {	//top left
			GUI.Box (new Rect(bbox.min.x - 2*bubble_padding - bubble_width, 
			                  bbox.min.y - 2*bubble_padding - bubble_height,
			                  bubble_width + 2*bubble_padding,
			                  bubble_height + 2*bubble_padding), "");				//draw bounding box
			GUI.Label (new Rect(bbox.min.x - bubble_padding - bubble_width,
			                    bbox.min.y - bubble_padding - bubble_height,
			                    bubble_width,
			                    bubble_height), dialog[dindex], style);				//render dialog
		}
		else if (fitright && fitbot) {	//bot right
			GUI.Box (new Rect(bbox.max.x, 
			                  bbox.max.y,
			                  bubble_width + 2*bubble_padding,
			                  bubble_height + 2*bubble_padding), "");				//draw bounding box
			GUI.Label (new Rect(bbox.max.x + bubble_padding,
			                    bbox.max.y + bubble_padding,
			                    bubble_width,
			                    bubble_height), dialog[dindex], style);				//render dialog
		}
		else if (fitleft && fitbot) {	//bot left
			GUI.Box (new Rect(bbox.min.x - 2*bubble_padding - bubble_width, 
			                  bbox.max.y,
			                  bubble_width + 2*bubble_padding,
			                  bubble_height + 2*bubble_padding), "");				//draw bounding box
			GUI.Label (new Rect(bbox.min.x - bubble_padding - bubble_width,
			                    bbox.max.y + bubble_padding,
			                    bubble_width,
			                    bubble_height), dialog[dindex], style);				//render dialog
		}
	}

	//overall function to animate all dialogs still contained in the dialog/bubble text class object
	public void UpdateDialogs() {

		//current time
		float current_time = Time.time;

		//scroll through each dialog (from end to start), for removing safely purposes
		for (int i = num_dialogs-1; i >=0; i--) {
			if (current_time - start_time[i] > time_duration[i])		//dialog expired already
			{
				RemoveDialog(i);										//remove our dialog at i
			}
			else {														//render our dialog if it isn't expired
				DrawBubbleText(i);										//render bubble text
			}
		}

	}

}


