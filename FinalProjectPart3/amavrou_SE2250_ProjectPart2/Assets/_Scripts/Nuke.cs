using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nuke : MonoBehaviour {
	Text nuke;
	// Use this for initialization
	void Awake(){
		nuke = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		nuke.text = "Nukes: " + Hero.S.nukes;
	}
}