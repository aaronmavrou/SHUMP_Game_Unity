﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[Header("Set Dynamically")]
	[SerializeField]
	private WeaponType    _type;

		// This public property masks the field _type & takes action when it is set
		public WeaponType    type {
			get {
				return( _type );
			}
			set {
				SetType( value );
			}
		}

		void Awake() {
			// Test to see whether this has passed off screen every 2 seconds
			InvokeRepeating( "CheckOffscreen", 2f, 2f );
		}

		public void SetType( WeaponType eType ) {
			// Set the _type
			
			_type = eType;
			WeaponDefinition def = Main.GetWeaponDefinition( _type );
			GetComponent<Renderer>().material.color = def.projectileColor;
		}

		void CheckOffscreen() {
		if ( Utils.ScreenBoundsCheck( GetComponent<Collider>().bounds, BoundsTest.offScreen ) != Vector3.zero ) {
				Destroy( this.gameObject );
			}
		}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
