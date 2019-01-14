using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_1_Script : Enemy {
		// Because Enemy_1 extends Enemy, the _____ bool won't work             // 1
		//   the same way in the Inspector pane. :/

	    private int direction;

		void Start() {
			// Set x0 to the initial x position of Enemy_1
			// This works fine because the position will have already
			//   been set by Main.SpawnEnemy() before Start() runs
			//   (though Awake() would have been too early!).
			// This is also good because there is no Start() method
			//   on Enemy.

		direction = Random.Range (0, 2);

		}

		// Override the Move function on Enemy
		public override void Move() {                                           // 2
			// Because pos is a property, you can't directly set pos.x
			//   so get the pos as an editable Vector3
			Vector3 tempPos = pos;
			 
		if (direction ==1 ) {
			tempPos.x -= speed * Time.deltaTime;
		} else if (direction ==0) {
			tempPos.x += speed * Time.deltaTime;
		}

			pos = tempPos;

			// base.Move() still handles the movement down in y
			base.Move();                                                // 3

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
