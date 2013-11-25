using UnityEngine;
using System.Collections;
using Utils;

public class dave : MonoBehaviour {

	Utils.Directions direction=Directions.NONE;
	Animator animator;
	float speed=3000f;
	Vector3 tmpVector3;
	bool CanJump=true;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		if (CanJump) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				rigidbody2D.AddForce(new Vector2(0f, 100000f));
				CanJump=false;
			}
		}

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
	}

	void Update () {
		Debug.Log (rigidbody2D.velocity);
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
