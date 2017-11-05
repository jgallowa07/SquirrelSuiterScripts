using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //private GameObject tilZ;
    //public Vector3 from = new Vector3(0f, 0f, 100f);
    //public Vector3 to = new Vector3(500f, 0f,100f);
    private Transform  playerTransform;
    public float speed = 1.0f;
    //private float myZ;
    private int randomIndex;
    private int randomIndex2;
    private float startTime;
    //private float speed;
    // Use this for initialization
    void Start () {
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //myZ = playerTransform.position.z;
        startTime = Time.time;
        randomIndex = Random.Range(0,10);
        //randomIndex2 = Random.Range(50,450);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //myZ = transform.parent.position.z;
        float timeFromStart = Time.time - startTime;
        Vector3 from = new Vector3(240, transform.position.y, transform.position.z);
        Vector3 to = new Vector3(500, transform.position.y, transform.position.z);
        //float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
        float t = (Mathf.Sin(timeFromStart + randomIndex * speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        transform.position = Vector3.Lerp(from, to, t);
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime * 10);
    }
}
