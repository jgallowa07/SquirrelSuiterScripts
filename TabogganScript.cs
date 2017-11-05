using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabogganScript : MonoBehaviour {

    public bool moving = true;
    public int L2R = -1;

    private float speed = .5f;
    private float startTime;
    private bool flipped = true;

    void Start () {
        startTime = Time.time;
        speed = Random.Range(.25f, .6f);
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void Update () {
        if (!moving) {
            return;
        }
        float timeFromStart = Time.time - startTime;
        Vector3 from = new Vector3(0, 0f, transform.position.z);
        Vector3 to = new Vector3(500, 0f, transform.position.z);
        float t = Mathf.Sin(timeFromStart * speed * Mathf.PI);
        if (Mathf.Abs(t) > .99f) {
            //GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            if (!flipped) {
                flipped = true;
                transform.Rotate(0, L2R*180, 0);
            }
        } else {
            flipped = false;
        }
        if (L2R == 1) {
            transform.position = Vector3.Lerp(from, to, t);
        } else {
            transform.position = Vector3.Lerp(to, from, t);
        }
    }

}
