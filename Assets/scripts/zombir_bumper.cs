using UnityEngine;
using System.Collections;
using Utils;

public class zombir_bumper : MonoBehaviour {

	zombie z;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		zombie z = transform.parent.gameObject.GetComponent<zombie>(); //todo проверить, точно ли здесь получать?
	
		if (col.gameObject.CompareTag("World")){
			switch (z.direction) {
			case Directions.LEFT:
				z.direction=Directions.RIGHT;
				break;
			case Directions.RIGHT:
				z.direction=Directions.LEFT;
				break;
			};
		}
	} 
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
