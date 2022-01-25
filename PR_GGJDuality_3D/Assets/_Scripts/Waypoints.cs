using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour

{
    public GameObject[] waypoints;
    public float speed;

    int current = 0;
    float rotSpeed;    
    float wPradius = 1;

    // Update is called once per frame
    void Update()   
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < wPradius) ;
        {
           current = Random.Range(0, waypoints.Length);
            if (current >= waypoints.Length)
            {
                current = 0;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
