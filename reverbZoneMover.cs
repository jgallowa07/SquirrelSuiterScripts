using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverbZoneMover : MonoBehaviour {

	public GameObject squirrel;
	private Transform transform;
	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = squirrel.transform.position;
	}
}
