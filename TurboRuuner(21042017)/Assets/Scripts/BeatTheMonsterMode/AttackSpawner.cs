using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] Prefab;
	public GameObject[] Clone;

	public int spawnRandomPos;
	public float spawnRandomTime;
	public float spawnWaitMin;
	public float spawnWaitMax;
	public int StartWait;
	public bool stop;
	public bool Attacktwo = false;


	void Start(){
		StartCoroutine (WaitSpawer ());
	}

	void Update(){
		
		spawnRandomPos = Random.Range (0, 2);
		spawnRandomTime = Random.Range (spawnWaitMin, spawnWaitMax);
	}

	IEnumerator WaitSpawer(){
		yield return new WaitForSeconds (StartWait);



		while(!stop) {
				Clone [0] = Instantiate (Prefab [0], spawnLocations [spawnRandomPos].transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;//ball
				if (Attacktwo) {
					Clone [1] = Instantiate (Prefab [1], spawnLocations [2].transform.position, Quaternion.Euler (0, 90, 0)) as GameObject;
				}
				yield return new WaitForSeconds (spawnRandomTime);
			}
	}

	void OnTriggerEnter (Collider hit){
		if (hit.gameObject.name == "StartAtt2") {
			Attacktwo = true;
		}
	}
}
