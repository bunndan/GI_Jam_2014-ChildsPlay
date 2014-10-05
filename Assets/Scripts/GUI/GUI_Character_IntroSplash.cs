using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//splash screen intro for each character
public class GUI_Character_IntroSplash
{
	public Texture2D charArt;			//character art
	public int current_step;			//current step
	public int s_transition;			//total steps for entering/leaving art
	public int s_splash;				//total steps for art staying there
	public int trans_direction;			//start from the left? 
	public bool animating;				//are we animating the object now?
	public int art_height;
	public int art_width;
	float x_step_transition;			//x step size (in units)
	float x_to_pixel_scale;				//scale value to ensure that art is out of screen at current_step = 0 and current_step = last step
	int x_center;
	int ypx;							//y position of art

	//constructor
	public GUI_Character_IntroSplash (Texture2D character_art, int steps_to_transition, int steps_to_stay)
	{
		//intialize values
		charArt = character_art;
		s_transition = steps_to_transition;
		s_splash = steps_to_stay;
		animating = false;
		current_step = 0;

		//compute some useful params
		art_height = charArt.height;
		art_width = charArt.width;
		x_step_transition = Mathf.PI / ((float)s_transition);				//x step size
		x_to_pixel_scale = ((Screen.width + art_width)/2) / Mathf.PI;		//not exactly correct but it'll do.
		x_center = (int)((Screen.width - art_width) / 2);		
		ypx = (int)((Screen.height - art_height) / 2);
	}
	
	public void StartFromLeft(){
		Reset ();
		trans_direction = -1;
		animating = true;
	}

	public void StartFromRight(){
		Reset ();
		trans_direction = 1;
		animating = true;
	}

	public void Reset(){
		animating = false;
		current_step = 0;
	}

	public void Animate(){

		//currently animating?
		if (animating && current_step < (2*s_transition + s_splash)) {

			float x;
			int xpx;

			//check which state we are in currently
			if (current_step < s_transition){													//initial transition
				x = current_step * x_step_transition - Mathf.PI;						
				xpx = x_center + trans_direction*(int)(x_to_pixel_scale * x * Mathf.Cos(x));
				GUI.Label (new Rect(xpx, ypx, art_width, art_height), charArt);					//draw the art on screen
			}
			else if (current_step < s_transition + s_splash){	//waiting
				GUI.Label (new Rect(x_center, ypx, art_width, art_height), charArt);			//draw the art on screen
			}
			else{												//exit transition
				x = (current_step - s_splash) * x_step_transition - Mathf.PI;						
				xpx = x_center + trans_direction*(int)(x_to_pixel_scale * x * Mathf.Cos(x));
				GUI.Label (new Rect(xpx, ypx, art_width, art_height), charArt);					//draw the art on screen
			}
		}
		else {									//done animation
			Reset();
		}

		current_step = current_step + 1;
	}

}


