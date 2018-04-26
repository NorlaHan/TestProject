using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("Vertical")) {
			if (CrossPlatformInputManager.GetAxisRaw("Vertical") > 0) {
				Debug.Log ("W is pressed");
			}else{
				Debug.Log ("S is pressed");
			}
		}else if (CrossPlatformInputManager.GetButtonDown("Horizontal")) {
			if (CrossPlatformInputManager.GetAxisRaw("Vertical")>0) {
				Debug.Log ("D is pressed");
			}else{
				Debug.Log ("A is pressed");
			}
		}
	}
}
