using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Rigidbody CameraRB;
	int speed=10;
	Transform target;

	// Use this for initialization
	void Start () {
		CameraRB = GetComponent<Rigidbody> ();
		target = GameObject.Find ("Cube").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		CameraRB.velocity = new Vector3 (0, 0, speed);
		transform.LookAt (target);
	}
}
