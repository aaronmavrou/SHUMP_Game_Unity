using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {
	[Header ("Set in Inspector")]
	public Text levelUpText;
	public float delayLevelUp = 1f;

	[Header ("Set Dynamically")]
	static public bool LEVELUP = false;
	static public int SCORE_REQUIREMENT = 2500;
	static public int  CUR_LEVEL = 1;

	static public LevelUp L;
	void Start(){
		levelUpText.gameObject.SetActive (false);

	}

	void Awake ()
	{
		if (L == null) {
			L = this;
		} else {
			Debug.LogError ("ERROR: NewLevel.Awake(): L is already set!");
		}
	}

	static public void CheckLevelUp ()
	{
		if (Main.S.score >= SCORE_REQUIREMENT) {
			LEVELUP = true;
			L.NewGame ();
		}
	}

	void NewGame ()
	{
		L.levelUpText.text = "Level Up!";
		CUR_LEVEL++;
		L.levelUpText.gameObject.SetActive (true);
		if (Main.S.enemeyNum < 3)
			Main.S.enemeyNum++; //Add a new enemy to instantiated enemies;
		if (CUR_LEVEL > 3 && CUR_LEVEL < 13) { //enemies spawn faster
			Main.S.enemySpawnRate -= 0.15f;
		}
		levelUpText.text = "Level: " + CUR_LEVEL;
		Invoke ("hideLevelUpText", L.delayLevelUp);
	}

	private void hideLevelUpText ()
	{
		levelUpText.gameObject.SetActive (false);
		LEVELUP = false;
		SCORE_REQUIREMENT += 2500;
	}
		
}
