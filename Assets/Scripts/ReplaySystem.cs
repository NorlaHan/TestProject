using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

	public GameObject gameManagerPrefab;
	//public Vector3 lastVelocity;
	public int lastFrame = 0;

	private const int bufferFrames = 200;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];
	private Rigidbody rigidBody;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		if (GetComponent<Rigidbody> ()) {
			rigidBody = GetComponent<Rigidbody> ();
		} else {
			gameObject.AddComponent<Rigidbody> ();
			Debug.LogWarning (name +", missing Rigidbody, auto generated one");
		}
		if (GameObject.FindObjectOfType<GameManager> ()) {
			gameManager = GameObject.FindObjectOfType<GameManager> ();
		} else {
			Debug.LogWarning (name + ", missing GameManager. instantiate one");
			gameManager = GameObject.Instantiate (gameManagerPrefab).GetComponent<GameManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.isGameRecording()) {
			Record ();
		} else {
			PlayBack ();
		}

	}

	void Record ()
	{
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
//		Debug.Log (name + ", Writing frame : " + frame);
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
		//lastVelocity = rigidBody.velocity;
		lastFrame = frame;
	}

	void PlayBack (){
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % lastFrame ;
//		Debug.Log (name + ", reading frame : "+ frame);
		transform.position = keyFrames [frame].framePos;
		transform.rotation = keyFrames [frame].frameRot;
	}
}

/// <summary>
/// A structure for sorting time, position and rotation.
/// </summary>
public struct MyKeyFrame {
	public float frameTime;
	public Vector3 framePos;
	public Quaternion frameRot;

	public MyKeyFrame (float time, Vector3 pos, Quaternion rot){
		this.frameTime = time;
		this.framePos = pos;
		this.frameRot = rot;
	}
}
