using UnityEngine;
using System.Collections;

public class GMScript : MonoBehaviour {

	public Texture2D hpIcon;
	public Texture2D moneyIcon;
	public Texture2D splash;
	GUI_Player_Stats playerStats;
	GUI_Character_IntroSplash introSplash;
	GUI_Bubble_Text bubbleText;

	public int currentHP  = 5;
	public int currentMoney = 5;
	public int maxHP      = 5;
	public int maxMoney   = 5;
	public int spacing    = 10;
	public int textsize   = 10;
	public int dialogDuration = 5;
	
	// Use this for initialization
	void Start () {
		playerStats = new GUI_Player_Stats (hpIcon, moneyIcon, currentHP, currentMoney, maxHP, maxMoney);
		bubbleText = new GUI_Bubble_Text ();
		bubbleText.AddDialog (GameObject.Find ("Player"), "Lorem Ipsum.", 100, dialogDuration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		playerStats.DrawPlayerStats (spacing, textsize);
		// bubbleText.UpdateDialogs ();
	}
}
