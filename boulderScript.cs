using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderScript : MonoBehaviour
{
    /*
    //private GameObject tilZ;
    //public Vector3 from = new Vector3(0f, 0f, 100f);
    //public Vector3 to = new Vector3(500f, 0f,100f);
    private Transform playerTransform;
    public float speed = 1.0f;
    private float myZ;
    private int randomIndex;
    private int randomIndex2;
    private float startTime;
    //private float speed;
    // Use this for initialization
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myZ = playerTransform.position.z;
        startTime = Time.time;
        randomIndex = Random.Range(50,100);
        //randomIndex2 = Random.Range(50,450);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //myZ = transform.parent.position.z;
        float timeFromStart = Time.time - startTime;
        Vector3 from = new Vector3(0, randomIndex, transform.position.z);
        Vector3 to = new Vector3(500, randomIndex, transform.position.z);
        //float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
        float t = (Mathf.Sin(timeFromStart * speed * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
        transform.position = Vector3.Lerp(from, to, t);
    }
    */
    public GameObject squirrel;
    //public ParticleSystem smokeLanding;
    //public ParticleSystem fireTrail;
    private Transform squirrelTransform;
    //private GameObject snowball;
    private Vector3 destination;
    private Vector3 startPos;
    private float startTime;
    private ParticleSystem particles;
    private float randoX, randoY, randoZ;
    private bool rotating;


    // Use this for initialization
    void Start()
    {

        squirrelTransform = squirrel.GetComponent<Transform>();
		float squirrelSpeed = squirrel.GetComponent<SquirrelController> ().forwardSpeed;

        if (squirrelTransform.position.z < 7.0f)
        {
            startPos = new Vector3(0, -5000.0f, 0);
            destination = startPos;
        }
        //transform = GetComponent<Transform> ();
        else
        {
			destination = squirrelTransform.position + new Vector3(0, -(squirrelTransform.position.y + 10), 3.0f * squirrelSpeed);
			startPos = new Vector3(Random.Range(-50.0f, 550.0f), 350.0f, squirrelTransform.position.z + 500.0f + 1.75f * squirrelSpeed);
            //transform.position = startPos;
            startTime = Time.time;
            //randoX = Random.Range(0, 10.0f);
            //randoY = Random.Range(0, 10.0f);
            //randoZ = Random.Range(0, 10.0f);
            rotating = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotating)
        {
            //transform.Rotate(Time.time / randoX, Time.time / randoY, Time.time / randoZ);
            transform.position = Vector3.Lerp(startPos, destination, (Time.time - startTime) / 1.7f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Obstacle"))
        {
            //fireTrail.Stop();
            //smokeLanding.Play();
            rotating = false;
            //this.gameObject.SetActive(false);
        }
    }
}
