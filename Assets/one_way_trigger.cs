using UnityEngine;
using System.Collections;

public class one_way_trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("11111");

        if (col.CompareTag("OneWayTrigger"))
        {
            Debug.Log("enter");
            gameObject.layer = 13; //todo magic number
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("2222");

        if (col.CompareTag("OneWayTrigger"))
        {
            Debug.Log("exit");
            gameObject.layer = 8; //todo magic number
        }
    }
}
