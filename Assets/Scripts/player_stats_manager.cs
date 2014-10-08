using UnityEngine;
using System.Collections;

public class player_stats_manager : MonoBehaviour {

	//create a singleton of this object
	private static player_stats_manager instance = null;
	public static player_stats_manager Instance {
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

	//Player statistics and gui
	public Texture2D hpIcon;
	public Texture2D moneyIcon;
	GUI_Player_Stats playerStats;
	
	public int currentHP  = 5;
	public int currentMoney = 5;
	public int maxHP      = 5;
	public int maxMoney   = 5;
	public int spacing    = 10;
	public int textsize   = 10;
	
	// Use this for initialization
	void Start () {
		playerStats = new GUI_Player_Stats (hpIcon, moneyIcon, currentHP, currentMoney, maxHP, maxMoney);
	}
	
	// Update is called once per frame
	void Update () {
	}

	//just display player health and money
	void OnGUI () {
		playerStats.DrawPlayerStats (spacing, textsize);
	}
}
