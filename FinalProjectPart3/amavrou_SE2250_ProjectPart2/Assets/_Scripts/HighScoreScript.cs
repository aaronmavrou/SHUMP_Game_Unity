using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {
	Text highscore;
	static public int HIGH_SCORE = 0;
	// Use this for initialization
	void Start () {
		highscore = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		highscore.text = "HIGH SCORE: " + HIGH_SCORE;
		if (Main.S.score >= HIGH_SCORE) {
			HIGH_SCORE = Main.S.score;
		}
	}
}
