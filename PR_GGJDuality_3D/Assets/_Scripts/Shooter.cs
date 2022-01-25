using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject shooter;
    public GameObject projectile;

    float timer;
    public int waitingTime;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            
            GameObject bullets = Instantiate(projectile) as GameObject;
            bullets.transform.position = transform.position * 1;

            Rigidbody rb = bullets.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
            Destroy(bullets, 1f);

            timer -= waitingTime;
        }


    }
}
