using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator1 : MonoBehaviour,ObstacleCreatorMain {
	public GameObject[] Obstacles;
	Transform player;
	Vector3 pose;
	Quaternion rotate;
	//To remember a gate is created;
	public bool G1;
	//To remember which type of object is created
	bool[] TypeOfobstacle;
	public int[] TimeToFinishCreationOfaObstacle;
	bool signalNext;
	bool wait;
	//Script referance
	ObstacleCreator2 obsC2;
	ObstacleCreator3 obsC3;



	void Start(){
//		Obstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
//		foreach (GameObject g in Obstacles) {
//			Debug.Log (g.name);
//		}
		player = GameObject.Find ("Car2").GetComponent<Transform> ();
		TypeOfobstacle = new bool[Obstacles.Length];
		obsC2 = GameObject.Find ("ObstacleCreator2").GetComponent<ObstacleCreator2> ();
		obsC3 = GameObject.Find ("ObstacleCreator3").GetComponent<ObstacleCreator3> ();

	}

	void Update(){
		if (signalNext == false && obsC2.G2 == false && obsC3.G3 == false && wait==false) {
			signalNext = true;
			StartCoroutine ("Create");
		}
		Debug.Log ("signalNext "+signalNext);
		Debug.Log ("obsC2.G2 "+obsC2.G2);
		Debug.Log ("obsC3.G3 "+obsC3.G3);
		Debug.Log ("wait "+wait);
	}

	void OnTriggerExit(Collider obj){
		signalNext = false;
		G1 = false;
	}

	IEnumerator Create(){
		int rvar = Random.Range (0, Obstacles.Length);
		Debug.Log (Obstacles.Length);
		TypeOfobstacle [rvar] = true;
		pose = transform.position;
		rotate = Obstacles [rvar].transform.rotation;

		if (rvar == 1) {
			G1 = true;
			Instantiate (Obstacles [0], new Vector3(0,0,pose.z), rotate);
		} else {
			Instantiate (Obstacles [rvar], pose, rotate);
		}
		yield return new WaitForSeconds(TimeToFinishCreationOfaObstacle[rvar]);
		wait = false;
	}
}
