using UnityEngine;
using System.Collections;

public class game_manager : MonoBehaviour {

	public AudioClip LevelMusic; //Pick an audio track to play.
	
	void Awake ()
	{
		var go = GameObject.Find("Game Music"); //Finds the game object called Game Music, if it goes by a different name, change this.
		go.audio.clip = LevelMusic; 			//Replaces the old audio with the new one set in the inspector.
		go.audio.Play(); 						//Plays the audio.
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

}
