using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner: MonoBehaviour {


	public GameObject[] enemies;
	//public Vector3 spawnValues;
	public float spawnWait;
	public int startWait;
	public bool stop;

	public GameObject monster;



	int randEnemy;

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
			randEnemy = Random.Range (0, 2);

			Vector3 spawnPosition = new Vector3 (Random.Range(-monster.transform.localScale.x/2,monster.transform.localScale.x/2), monster.transform.localScale.y-5, 1);

			Instantiate (enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
