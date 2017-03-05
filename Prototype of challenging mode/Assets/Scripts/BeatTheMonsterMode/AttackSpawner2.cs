using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner2 : MonoBehaviour {

	public GameObject[] enemies;
	//public Vector3 spawnValues;
	public float spawnWait;
	public int startWait;
	public bool stop;

	public GameObject monster;


	// Use this for initialization
	void Start () {

		StartCoroutine (WaitSpawer ());

	}

	// Update is called once per frame
	void Update () {


	}

	IEnumerator WaitSpawer()
	{
		yield return new WaitForSeconds(startWait);

		while (!stop) 
		{

			Vector3 spawnPosition = new Vector3 (monster.transform.position.x,monster.transform.position.y,monster.transform.position.z);



			Instantiate (enemies [0], spawnPosition, Quaternion.Euler (0, 0, 90));

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
