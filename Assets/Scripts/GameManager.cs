using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool isRecording = true;
	private float fixedDeltaTime;

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.UnlockLevel (2);
		Debug.Log (PlayerPrefsManager.IsLevelUnlocked(0));
		Debug.Log (PlayerPrefsManager.IsLevelUnlocked(1));
		Debug.Log (PlayerPrefsManager.IsLevelUnlocked(2));

		fixedDeltaTime = Time.fixedDeltaTime;
		Debug.Log ("Time.fixedDeltaTime is " +Time.fixedDeltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButton ("Fire1")) {
			isRecording = false;
			//Debug.Log ("Stop recording");
		} else {
			isRecording = true;
			//Debug.Log ("Recording!");
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale != 0) {
				Paused ();
			}else {
				Resume ();
			}
		} 

		Debug.Log ("Updating...");
	}

	private void Paused ()
	{
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	private void Resume ()
	{
		Time.timeScale = 1;
		Time.fixedDeltaTime = fixedDeltaTime;
	}

	public void TouchInputRelpay (){
		if (isRecording == true) {
			isRecording = false;
			Debug.Log("REPLAY");
		} else {
			isRecording = true;
			Debug.Log("RECORDING");
		}

	}

	public bool isGameRecording(){
		return isRecording;
	}
}
