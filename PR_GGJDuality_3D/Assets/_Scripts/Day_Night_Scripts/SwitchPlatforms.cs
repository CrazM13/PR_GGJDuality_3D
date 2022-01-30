using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatforms : MonoBehaviour
{
    private bool day = true;
    [SerializeField]private bool pressed = false;
    private GameObject[] dayObjects;
    private GameObject[] nightObjects;
    [SerializeField] private bool restricted;
    private float timer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        dayObjects = GameObject.FindGameObjectsWithTag("day");
        nightObjects = GameObject.FindGameObjectsWithTag("night");
        restricted = false;

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

        if(restricted == true)
        {
            pressed = true;
            timer -= Time.deltaTime;
            if(timer <= 0f)
            {
                day = !day;
                timer = 5.0f;
            }
        }

        if ((Input.GetAxis("Switch Time") > 0) && (pressed == false) && (restricted == false))
        {
            pressed = true;
            day = !day;
            Debug.Log("This is being pressed");
            timer = 5.0f;
        }
        if((Input.GetAxis("Switch Time") == 0) && (restricted == false))
        {
            pressed = false;
            timer = 5.0f;
        }

    }

    public void setRestrictedTrue()
    {
        restricted = true;
    }

    public void setRestrictedFalse()
    {
        restricted = false;
    }

    public bool getDay()
    {
        return day;
    }
}
