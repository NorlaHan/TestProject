using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

	private GameObject player;
	private Vector3 armRotation;

	// Use this for initialization
	void Start () {

		if (GameObject.FindWithTag ("Player")) {
			player = GameObject.FindWithTag ("Player").gameObject;
		} else {
			Debug.LogWarning (name + ", missing Player.");
		}

		armRotation = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		armRotation.y += Input.GetAxis ("2ndHorizontal");
		armRotation.z += Input.GetAxis ("2ndVertical");
		transform.eulerAngles = armRotation;
		transform.position = player.transform.position;
	}
}
