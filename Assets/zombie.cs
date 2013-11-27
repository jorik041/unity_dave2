using UnityEngine;
using System.Collections;
using Utils;

public class zombie : MonoBehaviour {

	Utils.Directions direction=Directions.LEFT;
	Animator animator;
	float speed=30f;
	float MaxSpeed=1f;
	Vector3 tmpVector3;
	private Transform down_bump;
	
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		switch (direction) {
		case Directions.LEFT:
			rigidbody2D.AddForce(-Vector2.right * speed);
			animator.Play("move");

			tmpVector3=transform.localScale;
			tmpVector3.x=-1;
			transform.localScale=tmpVector3;
			break;
		case Directions.RIGHT:
			rigidbody2D.AddForce(Vector2.right * speed);
			animator.Play("move");

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
