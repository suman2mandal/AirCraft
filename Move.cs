using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	float SmallMovefact = 0.1f;
	bool MovingLeft=false;
	bool MovingRight=false;
	float SmallIntervalBetweenAMove = 0.001f;
	CameraFollow CFScript;
	Vector3 CurrentCamerapos;
	Vector3 offset;
	Vector3 MoveOffset;
	int currentX;
	int MoveDist=5;

	// Use this for initialization
	void Start () {
		CFScript = GameObject.Find ("Main Camera").GetComponent<CameraFollow> ();
		offset = new Vector3 (0,-1,10);
	}

	void FixedUpdate(){
		CurrentCamerapos = CFScript.transform.position;
		if (MovingLeft || MovingRight) {
			transform.position = new Vector3 (MoveOffset.x, MoveOffset.y + CurrentCamerapos.y + offset.y, CurrentCamerapos.z + offset.z);
		} else {
			transform.position = new Vector3 (currentX,MoveOffset.y + CurrentCamerapos.y + offset.y, CurrentCamerapos.z + offset.z);
			Debug.Log (currentX);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && !MovingRight && !MovingLeft) {
			MovingLeft = true;
			currentX -= MoveDist;
			StartCoroutine ("left");
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && !MovingRight && !MovingLeft) {
			MovingRight = true;
			currentX += MoveDist;
			StartCoroutine ("right");
		}
	}

	IEnumerator left(){
		for (int i = 0; i < 10; i++) {
			MoveOffset = Vector3.Lerp (transform.position, transform.position + new Vector3 (-MoveDist,0,0), SmallMovefact);
			yield return new WaitForSeconds (SmallIntervalBetweenAMove);

			if (i == 9) {
				MovingLeft = false;
			}
		}
	}

	IEnumerator right(){
		for (int i = 0; i < 10; i++) {
			MoveOffset = Vector3.Lerp (transform.position, transform.position + new Vector3 (MoveDist,0,0), SmallMovefact);
			yield return new WaitForSeconds (SmallIntervalBetweenAMove);

			if (i == 9) {
				MovingRight = false;
			}
		}
	}
}
