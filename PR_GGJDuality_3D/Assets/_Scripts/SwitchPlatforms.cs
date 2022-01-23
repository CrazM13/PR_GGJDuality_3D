using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatforms : MonoBehaviour
{
    public bool day = true;
    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < gameObjects.Length; i++)
        {
            if(gameObjects[i].tag == "day" && day == true)
            {
                //Reds turn on
            }
            else if(gameObjects[i].tag == "day" && day == true)
            {
                //reds turn off
            }
            else if (gameObjects[i].tag == "night" && day == true)
            {
                //blues turn off
            }
            else if (gameObjects[i].tag == "night" && day == false)
            {
                //blues turn on
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].tag == "day" && day == true)
            {
                //Reds turn on
            }
            else if (gameObjects[i].tag == "day" && day == true)
            {
                //reds turn off
            }
            else if (gameObjects[i].tag == "night" && day == true)
            {
                //blues turn off
            }
            else if (gameObjects[i].tag == "night" && day == false)
            {
                //blues turn on
            }
        }

        if (Input.GetAxis("Submit") > 0)
        {
            Debug.Log("This is being pressed");
        }
    }
}
