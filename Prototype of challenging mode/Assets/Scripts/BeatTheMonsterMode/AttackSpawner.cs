using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner: MonoBehaviour {


	public GameObject[] enemies;
	public float spawnWait;
	public int startWait;
	public float spawnWaitMin;
	public float spawnWaitMax;
	public bool stop;
	public bool attacking =true;

	public GameObject monster;


	// Use this for initialization
	void Start () {
	   StartCoroutine (WaitSpawer ());
	}

	// Update is called once per frame
	void Update () {
		
		spawnWait = Random.Range (spawnWaitMin, spawnWaitMax);
	}
	IEnumerator WaitSpawer()
	{
		yield return new WaitForSeconds(startWait);
		while (!stop) 
		{
			Vector3 spawnPosition = new Vector3 (Random.Range(monster.transform.position.x -3,monster.transform.position.x +3),monster.transform.position.y,monster.transform.position.z);
			Instantiate (enemies [0], spawnPosition, Quaternion.identity);			
			yield return new WaitForSeconds (spawnWait);
		}
	}

}
