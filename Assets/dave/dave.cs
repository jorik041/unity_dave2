﻿using UnityEngine;
using System.Collections;
using Utils;

public class dave : MonoBehaviour {

	Utils.Directions direction=Directions.NONE;
	Animator animator;
	float speed=30f;
	float MaxSpeed=0.7f;
	Vector3 tmpVector3;
	private Transform down_bump;
	public AudioSource jumpStart;
	public AudioSource jumpEnd;
	bool oldGrounded;
	bool JumpButton=false;

	void Start () {
		animator = GetComponent<Animator>();
		down_bump = transform.Find("down_bumper");
	}
//todo периодически ломаются прыжки
	void FixedUpdate () {
		switch (direction) {
		case Directions.LEFT:
			rigidbody2D.AddForce(-Vector2.right * speed);
			animator.Play("move");
			break;
		case Directions.RIGHT:
			rigidbody2D.AddForce(Vector2.right * speed);
			animator.Play("move");
			break;
		case Directions.NONE:
			animator.Play("stand");
		break;
		};
		bool grounded = Physics2D.Linecast(transform.position, down_bump.position, 1 << LayerMask.NameToLayer("World")); 
		
		if (oldGrounded!=grounded && grounded==true){
			jumpEnd.Play();
		}
		
		if (grounded && JumpButton) {
			rigidbody2D.AddForce(new Vector2(0f, 220));
			jumpStart.Play();
		}
		oldGrounded=Physics2D.Linecast(transform.position, down_bump.position, 1 << LayerMask.NameToLayer("World"));
	}

	void Update () {
		
		JumpButton=Input.GetKeyDown (KeyCode.UpArrow);
		
		if (rigidbody2D.velocity.x > MaxSpeed) {
			Vector2 newVelocity = rigidbody2D.velocity;
			newVelocity.x = MaxSpeed;
			rigidbody2D.velocity = newVelocity;
		}
		if (rigidbody2D.velocity.x < -MaxSpeed) {
			Vector2 newVelocity = rigidbody2D.velocity;
			newVelocity.x = -MaxSpeed;
			rigidbody2D.velocity = newVelocity;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			tmpVector3=transform.localScale;
			tmpVector3.x=-1;
			transform.localScale=tmpVector3;
						direction = Directions.LEFT;
				} else
		if (Input.GetKey (KeyCode.RightArrow)) {
			tmpVector3=transform.localScale;
			tmpVector3.x=1;
			transform.localScale=tmpVector3;
						direction = Directions.RIGHT;
				} else {
						direction = Directions.NONE;
				}
				
		
	}
}
