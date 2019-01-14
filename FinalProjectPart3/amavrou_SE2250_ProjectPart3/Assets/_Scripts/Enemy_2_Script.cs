using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2_Script : Enemy {
	// Weapon fields
	static public Enemy_2_Script      S; // Singleton

	public Weapon            Enemyweapon;
	public bool ____________________________;
	private int direction;

	// Declare a new delegate type WeaponFireDelegate
	public delegate void WeaponFireDelegate();
	// Create a WeaponFireDelegate field named fireDelegate.
	public WeaponFireDelegate fireDelegate;


	// Use this for initialization
	void Start () {
		S = this;
		Enemyweapon.SetType(WeaponType.spread);
		Invoke ("Fire", 2f);
		direction = Random.Range (0, 2);

	}
	public override void Move() {                                           // 2
		// Because pos is a property, you can't directly set pos.x
		//   so get the pos as an editable Vector3
		Vector3 tempPos = pos;

		if (direction ==1 ) {
			tempPos.x -= (20f + speed) * Time.deltaTime;
		} else if (direction ==0) {
			tempPos.x += (20f + speed) * Time.deltaTime;
		}

		pos = tempPos;

		// base.Move() still handles the movement down in y
		base.Move();                                                // 3

	}

	public void Fire(){
		fireDelegate();
		Invoke ("Fire", 2f);
	}

	public override void CheckOffscreen() {
		// If bounds are still their default value...
		if (bounds.size == Vector3.zero) {
			// then set them
			bounds = Utils.CombineBoundsOfChildren(this.gameObject);
			// Also find the diff between bounds.center & transform.position
			boundsCenterOffset = bounds.center - transform.position;
		}

		// Every time, update the bounds to the current position
		bounds.center = transform.position + boundsCenterOffset;
		// Check to see whether the bounds are completely offscreen
		Vector3 off = Utils.ScreenBoundsCheck( bounds, BoundsTest.onScreen );
		if ( off != Vector3.zero ) {
			pos -= off;
			transform.position = pos;
			// If this enemy has gone off the bottom edge of the screen
			if (off.y < 0) {
				// then destroy it
				Destroy( this.gameObject );
			}
			if (off.x < 0 || off.x > 1){
				if (direction == 1) {
					direction = 0;
				} else if (direction == 0) {
					direction = 1;
				}
			}
		}
	}
}
