using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public bool isHorizontal = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isHorizontal) {
			Debug.Log ("Horizontal value is : " + CrossPlatformInputManager.GetAxis ("Horizontal"));

		} else {
			Debug.Log ("Vertical value is : " + CrossPlatformInputManager.GetAxis ("Vertical"));
		}

		if (CrossPlatformInputManager.GetButton("Vertical")) {
			isHorizontal = false;
			if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0) {
				Debug.Log ("W is pressed");
			}else{
				Debug.Log ("S is pressed");
			}
			Debug.Log ("Vertical value is : " + CrossPlatformInputManager.GetAxis("Vertical"));
		}else if (CrossPlatformInputManager.GetButton("Horizontal")) {
			isHorizontal = true;
			if (CrossPlatformInputManager.GetAxisRaw("Horizontal")>0) {
				Debug.Log ("D is pressed");
			}else{
				Debug.Log ("A is pressed");
			}
			Debug.Log ("Horizontal value is : " + CrossPlatformInputManager.GetAxis("Horizontal"));
		}
	}
}
