using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUI_Player_Stats
{
	public Texture2D hp_icon;
	public Texture2D money_icon;
	public int current_hp;
	public int current_money;
	public int max_hp;
	public int max_money;

	//constructor
	public GUI_Player_Stats (Texture2D HPIcon, Texture2D MoneyIcon, int StartHP, int StartMoney, int MaxHP, int MaxMoney)
	{
		//initialize some default values
		hp_icon = HPIcon;
		money_icon = MoneyIcon;
		current_hp = StartHP;
		current_money = StartMoney;
		max_hp = MaxHP;
		max_money = MaxMoney;
	}

	//increases hp by 1
	public void AddHP(){
		if (current_hp < max_hp) {
			current_hp = current_hp + 1;
		}
	}

	//decreases hp by 1
	public void RemoveHP(){
		if (current_hp > 0) {
			current_hp = current_hp - 1;
		}
	}

	//increases money by 1
	public void AddMoney(){
		if (current_money < max_money) {
			current_money = current_money + 1;
		}
	}
	
	//decreases money by 1
	public void RemoveMoney(){
		if (current_money > 0) {
			current_money = current_money - 1;
		}
	}

	//draws the player's stats on the screen
	public void DrawPlayerStats(int spacing, int textsize){
		//default to top left for now

		//set fixed height for font
		GUIStyle style = new GUIStyle();
		style.fontSize = textsize;
		style.normal.textColor = Color.white;
		style.hover.textColor = Color.gray;

		int textsize_inpx = (int)style.lineHeight;

		////determine the overal positioning of each item
		//determine sizes of each icon
		int hp_icon_size_x = hp_icon.width; 		int hp_icon_size_y = hp_icon.height;
		int money_icon_size_x = money_icon.width;	int money_icon_size_y = money_icon.height;

		//determine starting point for each item
		int hp_text_top_left_y = spacing;
		int hp_icon_top_left_y = hp_text_top_left_y + textsize_inpx + spacing;
		int money_text_top_left_y = hp_icon_top_left_y + hp_icon_size_y + spacing;
		int money_icon_top_left_y = money_text_top_left_y + textsize_inpx + spacing;

		//determine bounding box to make stats look good
		int max_hp_x_size = hp_icon_size_x * max_hp;
		int max_money_x_size = money_icon_size_x * max_money;
		int max_x_size = 2 * spacing;
		if (max_hp_x_size > max_money_x_size) {
			max_x_size = max_x_size + max_hp_x_size;
		} 
		else {
			max_x_size = max_x_size + max_money_x_size;
		}
		int max_y_size = money_icon_top_left_y + money_icon_size_y + spacing;

		//draw the box and rest of the stats
		GUI.Box (new Rect (0, 0, max_x_size, max_y_size), "");			//bounding box
		GUI.Label (new Rect (spacing,
		                     hp_text_top_left_y,
		                     max_x_size-spacing,
		                     textsize_inpx), 
		           "HP", style);							//hp text
		for (int i = 0; i < current_hp; i++) {							//draw each hp icon
			int sx = spacing + hp_icon_size_x*i;
			int sy = hp_icon_top_left_y;
			GUI.Label (new Rect (sx, 
			                     sy, 
			                     hp_icon_size_x, 
			                     hp_icon_size_y), 
			           hp_icon);
		}
		GUI.Label (new Rect (spacing,
		                     money_text_top_left_y,
		                     max_x_size-spacing,
		                     textsize_inpx), 
		           "Money", style);						//money text
		for (int i = 0; i < current_money; i++) {						//draw each money icon
			int sx = spacing + money_icon_size_x*i;
			int sy = money_icon_top_left_y;
			GUI.Label (new Rect (sx, 
			                     sy, 
			                     money_icon_size_x, 
			                     money_icon_size_y), 
			           money_icon);
		}
	}
}


