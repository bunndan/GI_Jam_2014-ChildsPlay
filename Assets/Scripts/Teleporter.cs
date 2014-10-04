using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	
	IEnumerator ChangeLevel()
	{
		float fadeTime = GameObject.Find("_GM").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);
		print ("test " + Application.loadedLevel + "  |  " + (Application.loadedLevel + 1));
		if (Application.loadedLevel <= 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

	
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "Player"){
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
