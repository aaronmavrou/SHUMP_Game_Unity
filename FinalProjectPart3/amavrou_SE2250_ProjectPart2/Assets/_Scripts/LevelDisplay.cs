using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {

	Text level;
	// Use this for initialization
	void Awake(){
		level = GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {
		level.text = "Level " + LevelUp.CUR_LEVEL;
	}
}
