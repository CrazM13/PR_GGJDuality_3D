using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedTriggerScript : MonoBehaviour
{

    [SerializeField] private GameObject time;
    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.FindGameObjectWithTag("time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        time.GetComponent<SwitchPlatforms>().setRestrictedTrue();
    }

    private void OnTriggerExit(Collider other)
    {
        time.GetComponent<SwitchPlatforms>().setRestrictedFalse();
    }
}
