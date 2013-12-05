using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	Transform player;

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//todo добавить лерп
		transform.position = new Vector3(player.transform.position.x,(player.transform.position.y+0.5f),transform.position.z);
	}
}
