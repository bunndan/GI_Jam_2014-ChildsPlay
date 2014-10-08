using UnityEngine;
using System.Collections;

public class game_music : MonoBehaviour {

	//create a singleton of this object
	private static game_music instance = null;
	public static game_music Instance {
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}