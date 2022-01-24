using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatforms : MonoBehaviour
{
    private bool day = true;
    private bool pressed = false;
    private GameObject[] dayObjects;
    private GameObject[] nightObjects;
    // Start is called before the first frame update
    void Start()
    {
        dayObjects = GameObject.FindGameObjectsWithTag("day");
        nightObjects = GameObject.FindGameObjectsWithTag("night");

        for(int i = 0; i < dayObjects.Length; i++)
        {
            if (day == true)
            {
                dayObjects[i].SetActive(true);
                //Reds turn on
            }
            else if (day == false)
            {
                dayObjects[i].SetActive(false);
                //reds turn off
            }
        }
        for (int i = 0; i < nightObjects.Length; i++)
        {
            if (day == true)
            {
                nightObjects[i].SetActive(false);
                //Reds turn on
            }
            else if (day == false)
            {
                nightObjects[i].SetActive(true);
                //reds turn off
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dayObjects.Length; i++)
        {
            if (day == true)
            {
                dayObjects[i].SetActive(true);
                //Reds turn on
            }
            else if (day == false)
            {
                dayObjects[i].SetActive(false);
                //reds turn off
            }
        }
        for (int i = 0; i < nightObjects.Length; i++)
        {
            if (day == true)
            {
                nightObjects[i].SetActive(false);
                //Reds turn on
            }
            else if (day == false)
            {
                nightObjects[i].SetActive(true);
                //reds turn off
            }
        }

        if ((Input.GetAxis("Submit") > 0) && (pressed == false))
        {
            pressed = true;
            day = !day;
            Debug.Log("This is being pressed");
        }
        if(Input.GetAxis("Submit") == 0)
        {
            pressed = false;
        }

    }
}
