using UnityEngine;
using System.Collections;
using Utils;

public class dave : MonoBehaviour {

	Utils.Directions direction=Directions.NONE;
	Animator animator;
	public static int Score=0;
	public AudioSource audioPoint;
	public GameObject dieAnimation;

	void Start () {
		animator = GetComponent<Animator>();
	}

	void FixedUpdate () {
		switch (direction) {
		case Directions.LEFT:
			transform.rotation=Quaternion.Euler(0, 180, 0);
			//rigidbody2D.velocity=-Vector2.right * speed;
			//transform.position+=-Vector3.right * speed;
			animator.Play("move");
			break;
		case Directions.RIGHT:
			transform.rotation=Quaternion.Euler(0, 0, 0);
			//rigidbody2D.velocity=Vector2.right * speed;
			//transform.position+=Vector3.right * speed;
			animator.Play("move");
			break;
		case Directions.NONE:
			animator.Play("stand");
		break;
		};
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
						direction = Directions.LEFT;
				} else
		if (Input.GetKey (KeyCode.RightArrow)) {
						direction = Directions.RIGHT;
				} else {
						direction = Directions.NONE;
				}
	}
}
