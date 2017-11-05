using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	private Light light;
	public float intensity;
	public float speed;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity = (float)(Mathf.Abs(Mathf.Sin (Time.time * speed))) * intensity;
	}
}
