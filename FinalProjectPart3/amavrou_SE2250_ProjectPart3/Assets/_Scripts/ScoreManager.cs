using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	Text score;
	// Use this for initialization
	void Awake(){
		score = GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + Main.S.score;
	}
}
