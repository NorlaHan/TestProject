using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour {

	public MyKeyFrame myKeyFrame;

	// Use this for initialization
	void Start () {
		print ("You found the sausage");
		print ("Something changed");
		print ("Added something else");
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time;
		Vector3 pos = transform.position;
		Quaternion rot = transform.rotation;
		myKeyFrame = new MyKeyFrame (time, pos, rot);
	}
}
