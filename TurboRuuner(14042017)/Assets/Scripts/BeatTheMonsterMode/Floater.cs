using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {
	
	private Transform seaPlane;
	private Cloth planeCloth;
	private int closesrVertextIndex = -1;

	void Start(){
		seaPlane = GameObject.Find ("Sea").transform;
		planeCloth = seaPlane.GetComponent<Cloth>();
	}
	

	void Update ()
	{
		GetClosestVertex ();
	}

	void GetClosestVertex(){
		for (int i = 0; i < planeCloth.vertices.Length; i++) {
			if (closesrVertextIndex == -1) {
				closesrVertextIndex = i;
			}

			float distance = Vector3.Distance (planeCloth.vertices[i],transform.position);
			float closesDistance = Vector3.Distance (planeCloth.vertices[closesrVertextIndex],transform.position);

			if (distance < closesDistance) {
				closesrVertextIndex = i;
			}
		}
		transform.position = new Vector3 (
			transform.position.x, 
			planeCloth.vertices [closesrVertextIndex].y, 
			transform.position.z
		);
	}
}
