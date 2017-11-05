using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour {
	
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {

		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

		if ((player.transform.position - transform.position).sqrMagnitude < 5000.0f) {
			transform.position = Vector3.Lerp (transform.position, player.transform.position, Time.deltaTime*6);
		}
	}
}
