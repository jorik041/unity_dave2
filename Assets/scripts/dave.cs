using UnityEngine;
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
    public AudioSource shootSound;
	bool oldGrounded;
	bool JumpButton=false;
    bool Shoot = false;
    bool grounded;

	void Start () {
		animator = GetComponent<Animator>();
		down_bump = transform.Find("down_bumper");
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("OneWayTrigger"))
        {
            Debug.Log("enter");
            gameObject.layer=13; //todo magic number
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("OneWayTrigger"))
        {
            Debug.Log("exit");
            gameObject.layer = 8; //todo magic number
        }
    }

	void FixedUpdate () {
        if (!Shoot)
        {
            switch (direction)
            {
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
		
		
		if (oldGrounded!=grounded && grounded==true){
			jumpEnd.Play();
		}


        oldGrounded = Physics2D.Linecast(transform.position, down_bump.position, 1 << LayerMask.NameToLayer("World") | 1 << LayerMask.NameToLayer("OneWayBlock"));
	}

    void StopShoot()
    {
        Shoot = false;
    }

	void Update () {
        grounded = Physics2D.Linecast(transform.position, down_bump.position, 1 << LayerMask.NameToLayer("World") | 1 << LayerMask.NameToLayer("OneWayBlock"));
		JumpButton=Input.GetKeyDown (KeyCode.UpArrow);

        Vector3 tmpv3 = transform.position;

        if (tmpVector3.x < 0)
        {
            tmpv3.x = tmpv3.x - 1.7f;
        }
        else
        {
            tmpv3.x = tmpv3.x + 1.7f;
        }

        //Debug.DrawLine(transform.position, tmpv3, Color.red);
        Debug.DrawLine(transform.position, down_bump.position);


        if (Input.GetKeyDown(KeyCode.Space) && !Shoot && grounded)
        {
            Shoot = true;
            animator.Play("shoot");
            RaycastHit2D hit;
            if (hit=Physics2D.Linecast(transform.position, tmpv3, 1 << LayerMask.NameToLayer("Monster")))
            {
                hit.transform.GetComponent<zombie>().HP--;
            }
            direction = Directions.NONE;
            shootSound.Play();
        }

        if (grounded && JumpButton && !Shoot)
        {
            rigidbody2D.AddForce(new Vector2(0f, 220));
            jumpStart.Play();
        }

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

        if (!Shoot)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                tmpVector3 = transform.localScale;
                tmpVector3.x = -1;
                transform.localScale = tmpVector3;
                direction = Directions.LEFT;
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    tmpVector3 = transform.localScale;
                    tmpVector3.x = 1;
                    transform.localScale = tmpVector3;
                    direction = Directions.RIGHT;
                }
                else
                {
                    direction = Directions.NONE;
                }
            }
        }

	}
}
