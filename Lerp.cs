using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour {

    // Use this for initialization
    //public GameObject Obstacle;
    public float speed = 1.0f;
    private float myZ;
    private int randomIndex;
    private int randomIndex2;
    //private int randomIndex3;
    private Transform playerTransform;
    private float startTime;
    //private static int numPenguins = 0;
    //private float speed;
    // Use this for initialization
    void Start()
    {
        //myZ = transform.parent.position.z;
        //numPenguins++;
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //myZ = playerTransform.position.z;
        //myZ = playerz;
        startTime = Time.time;
        //andomIndex = Random.Range(60, 440);
        randomIndex2 = Random.Range(70, 120);
        //randomIndex3 = Random.Range(0, 100);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //myZ = transform.parent.position.z;
        float timeFromStart = Time.time - startTime;
        Vector3 from = new Vector3(transform.position.x, -60, transform.position.z);
        Vector3 to = new Vector3(transform.position.x, randomIndex2, transform.position.z);
        //float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
        float t = (Mathf.Sin(timeFromStart * speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        transform.position = Vector3.Lerp(from, to, t);
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
