using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {

		if (GameObject.FindWithTag ("Player")) {
			player = GameObject.FindWithTag ("Player").gameObject;
		} else {
			Debug.LogWarning (name + ", missing Player.");
		}
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		Debug.Log ("2ndHorizontal is : "+ Input.GetAxis("2ndHorizontal"));
//		Debug.Log ("2ndVertical is : "+ Input.GetAxis("2ndVertical"));
		transform.LookAt (player.transform, Vector3.up);  // ((player.transform.position-transform.position), Vector3.up);
	}
}
