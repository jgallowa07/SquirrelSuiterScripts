using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{

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
    private float SqirSpeed;
    //public float spawnahead = 600f;


    // Use this for initialization
    void Start()
    {
        squirrel = GameObject.FindWithTag("Player");
        squirrelTransform = squirrel.GetComponent<Transform>();
        SqirSpeed = squirrel.GetComponent<SquirrelController>().forwardSpeed;
        if (squirrelTransform.position.z < 7.0f)
        {
            startPos = new Vector3(0, -5000.0f, 0);
            destination = startPos;
        }
        else
        {
            //transform = GetComponent<Transform> ();
            destination = squirrelTransform.position + new Vector3(0, -squirrelTransform.position.y, SqirSpeed*3);
            startPos = new Vector3(Random.Range(-50.0f, 550.0f), 200.0f, squirrelTransform.position.z + 500 + (SqirSpeed * 1.75f));
        }
        //transform.position = startPos;
        startTime = Time.time;
        //randoX = Random.Range(0, 10.0f);
        //randoY = Random.Range(0, 10.0f);
        //randoZ = Random.Range(0, 10.0f);
        rotating = true;
        Destroy(this,5);
        }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotating)
        {

            //Vector3 center = (startPos + destination) * 0.5F;
            //center -= new Vector3(0, 1, 1);
            //Vector3 riseRelCenter = startPos - center;
            //Vector3 setRelCenter = destination - center;
            //float fracComplete = (Time.time - startTime) / 1.7f;
            //transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            //transform.position += center;
            //transform.Rotate(Time.time / randoX, Time.time / randoY, Time.time / randoZ);
            //transform.position = 
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
/*
    public GameObject squirrel;
    private Vector3 startPos;
    private Transform squirrelTransform;
    private float shootAngle = 30;
    private float SqirSpeed;


    void start()
    {
        squirrelTransform = squirrel.GetComponent<Transform>();
        startPos = new Vector3(Random.Range(-50.0f, 550.0f), 40.0f, squirrelTransform.position.z + 500 + (SqirSpeed * 1.75f));
        SqirSpeed = squirrel.GetComponent<SquirrelController>().forwardSpeed;
        //rigidbody.velocity = BallisticVel(squirrelTransform,shootAngle);
        //destroy()
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = BallisticVel(squirrelTransform,shootAngle);
        //destroy(this,10);

    }

    Vector3 BallisticVel(Transform target, float angle)
    {
        var dir = target.position - transform.position;  // get target direction
        var h = dir.y;  // get height difference
        dir.y = 0;  // retain only the horizontal direction
        var dist = dir.magnitude ;  // get horizontal distance
        var a = angle * Mathf.Deg2Rad;  // convert angle to radians
        dir.y = dist * Mathf.Tan(a);  // set dir to the elevation angle
        dist += h / Mathf.Tan(a);  // correct for small height differences
        // calculate the velocity magnitude
        var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }*/
 
 //var myTarget: Transform;  // drag the target here
 //var cannonball: GameObject;  // drag the cannonball prefab here
 //var shootAngle: float = 30;  // elevation angle




}
