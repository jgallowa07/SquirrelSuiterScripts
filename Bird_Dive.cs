using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Dive : MonoBehaviour {
    private Transform squirrelTransform;
    private GameObject squirrel;

    private Vector3 destination;
    private Vector3 startPos;
    private Vector3 helper;
    private float startTime;
    private ParticleSystem particles;
    private float randoX, randoY, randoZ;
    private bool rotating;
    private float SqirSpeed;
    // Use this for initialization
    public Transform target;
    public float speed;
    void Start () {
        squirrelTransform = GameObject.FindGameObjectWithTag("Player").transform;
        squirrel = GameObject.FindGameObjectWithTag("AttackSquirrel");
        SqirSpeed = squirrelTransform.GetComponent<SquirrelController>().forwardSpeed;
        //transform.position
        //helper = new Vector3(0,0,-1.0f) ;
        if (squirrelTransform.position.z < 7.0f)
        {
            squirrel.SetActive(false);
            //startPos = new Vector3(0, -5000.0f, 0);
            //destination = startPos;
        }
        else
        {
            
            startPos = new Vector3(Random.Range(-50.0f, 550.0f), 6000.0f, squirrelTransform.position.z + 600 + (SqirSpeed * 1.75f));
			destination = /*squirrelTransform.position + new Vector3(0, 0, SqirSpeed * 3.2f);*/ startPos;
            //transform.position = startPos;
            startTime = Time.time;
            //squirrelTransform.ro
            randoX = Random.Range(0, 10.0f);
            randoY = Random.Range(0, 10.0f);
            randoZ = Random.Range(0, 10.0f);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //squirrelTransform = squirrelTransform.GetComponent<Transform>();
        //destination = squirrelTransform.position;
        transform.position = Vector3.Lerp(startPos, destination, (Time.time - startTime) / 3.0f);
        
        //transform.LookAt(squirrelTransform);
        //transform.position += new Vector3(0, 0, 5.0f);
        //startPos = new Vector3(Random.Range(25.0f, 300.0f), 500.0f, squirrelTransform.position.z + 200.0f);
    }
    void Update()
    {
        if (transform.position.z > squirrelTransform.position.z + 100.0f)
        {
            float step = speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, squirrelTransform.position, step);
        }
       
    }
    void OnCollisionEnter(Collision other)
    {
        /*
        if (squirrel == null)
        {
            squirrel.SetActive(false);
        }
        */
    }
   
}
