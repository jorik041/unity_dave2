﻿using UnityEngine;
using System.Collections;
using Utils;

public class zombie : MonoBehaviour {

	public Utils.Directions direction=Directions.LEFT;
	//Animator animator;
	float speed=30f;
	float MaxSpeed=0.2f;
	Vector3 tmpVector3;
	
	void Start () {
		//animator = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		/*if (col.gameObject.CompareTag("World")){
		switch (direction) {
		case Directions.LEFT:
			direction=Directions.RIGHT;
			break;
		case Directions.RIGHT:
			direction=Directions.LEFT;
			break;
		};
		}*/
	}
	
	void FixedUpdate () {
		switch (direction) {
		case Directions.LEFT:
			rigidbody2D.AddForce(-Vector2.right * speed);
			//animator.Play("move");

			tmpVector3=transform.localScale;
			tmpVector3.x=-1;
			transform.localScale=tmpVector3;
			break;
		case Directions.RIGHT:
			rigidbody2D.AddForce(Vector2.right * speed);
			//animator.Play("move");

			tmpVector3=transform.localScale;
			tmpVector3.x=1;
			transform.localScale=tmpVector3;
			break;
		};
		
	}
	
	void Update () {
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
	}

}
